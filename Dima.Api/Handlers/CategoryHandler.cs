using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dima.Api.Data;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers
{
    public class CategoryHandler(AppDbContext context) : ICategoryHandler
    {
        public async Task<Response<Category>> CreateAsync(CreateCategoryRequest request)
        {
            try
            {
                //instancia a categoria
                var category = new Category
                {
                    UserId = request.UserId,
                    Title = request.Title,
                    Description = request.Description
                };
                //salva no banco
                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();

                //retorna a categoria
                return new Response<Category>(category, 201);
            }
            catch
            {
                return new Response<Category?>(null, 500, "erro ao criar categoria");
            }
        }

        public Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<Category?>>> GetAllAsync(GetAllCategoriesRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
        {
            try
            {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
    
                if (category == null)
                {
                    return new Response<Category?>(null, 404, "Categoria não encontrada");
                }
                category.Title = request.Title;
                category.Description = request.Description;
    
                context.Categories.Update(category);
                await context.SaveChangesAsync();

                return new Response<Category?>(category, message: "Categoria atualizada com sucesso");
            }
            catch
            {
                return new Response<Category?>(null, 500, "Erro ao atualizar categoria");
            }
        }
    }
}