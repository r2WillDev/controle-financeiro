using Dima.Api.Data;
using Dima.Api.Handlers;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);

var cnnStr = builder
    .Configuration
    .GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services.AddDbContext<AppDbContext>(
    x =>
    {
        x.UseSqlServer(cnnStr);
    }
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.CustomSchemaIds(n => n.FullName);
});
builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.MapPost(
        "/v1/categories",
        async (CreateCategoryRequest request, ICategoryHandler handler)
        => await handler.CreateAsync(request))
    .WithSummary("Cria uma nova categoria")
    .WithName("Categories: Create")
    .Produces<Response<Category?>>();

app.MapPut(
        "/v1/categories/{id}",
        async (long id,
            UpdateCategoryRequest request, 
            ICategoryHandler handler) 
        =>
        {
            request.Id = id;
            return await handler.UpdateAsync(request);
            })
    .WithSummary("atualiza a categoria")
    .WithName("Categories: Update")
    .Produces<Response<Category?>>();

app.MapDelete(
        "/v1/categories/{id}",
        async (long id,
            //DeleteCategoryRequest request, 
        ICategoryHandler handler)
        => {
            var request =  new DeleteCategoryRequest
            {
                Id = id,
                UserId = "teste@testandomuito.com"
            };
            return await handler.DeleteAsync(request);
            })
    .WithSummary("deleta uma Categoria")
    .WithName("Categories: Delete")
    .Produces<Response<Category?>>();

app.MapGet(
        "/v1/categories/{id}",
        async (long id,
            //DeleteCategoryRequest request, 
        ICategoryHandler handler)
        => {
            var request =  new GetCategoryByIdRequest
            {
                Id = id,
                UserId = "teste@testandomuito.com"
            };
            return await handler.GetByIdAsync(request);
            })
    .WithSummary("retorna uma Categoria")
    .WithName("Categories: Get by Id")
    .Produces<Response<Category?>>();

app.MapGet(
        "/v1/categories/",
        async (
        ICategoryHandler handler)
        => {
            var request =  new GetAllCategoriesRequest
            {
                UserId = "teste@testandomuito.com"
            };
            return await handler.GetAllAsync(request);
            })
    .WithSummary("retorna todas Categoria")
    .WithName("Categories: Get by Id")
    .Produces<PagedResponse<List<Category>?>>();

app.Run();

//Request
// public class Request
// {
//     public string Title { get; set; } = string.Empty;
//     public string Description { get; set; } = string.Empty;
// }

// //response

// public class Response
// {
//     public long Id { get; set; }
//     public string Title { get; set; } = string.Empty;
// }

// //handler
// public class Handler(AppDbContext context)
// {
//     public Response Handle(Request request)
//     {
//         var category = new Category
//         {
//             Title = request.Title,
//             Description = request.Description
//         };

//         context.Categories.Add(category);
//         context.SaveChanges();

//         return new Response
//         {
//             Id = category.Id,
//             Title = category.Title
//         };
//     }
// }
