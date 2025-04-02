using Application.Request.Category;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ICategoryService
    {
        Task<ApiResponse> AddCategoryAsync(AddCategoryRequest request);
        Task<ApiResponse> RemoveCategoryAsync(int id);
        Task<ApiResponse> GetAllCategoryAsync();
        Task<ApiResponse> UpdateCategoryAsync(UpdateCategoryRequest request);
        Task<ApiResponse> GetCategoryByIdAsync(int id);
    }
}
