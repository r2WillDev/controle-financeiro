using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;

namespace Dima.Core.Handlers
{
    public interface ICategoryHandler // multiplas implementações
    {
        //Async ajuda na performance da aplicaçao	
        Task<Response<Category?>> CreateAsync(CreateCategoryRequest request);
        Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request);
        Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request);
        Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request);
        Task<Response<List<Category>>> GetAllAsync(GetAllCategoriesRequest request);
    }
}