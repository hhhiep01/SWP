using Application.Interface;
using Application.Request.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync(AddCategoryRequest request)
        {
            var result = await _service.AddCategoryAsync(request);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategoryAsync()
        {
            var result = await _service.GetAllCategoryAsync();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategoryAsync(UpdateCategoryRequest updateCategoryRequest)
        {
            var result = await _service.UpdateCategoryAsync(updateCategoryRequest);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            var result = await _service.RemoveCategoryAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
