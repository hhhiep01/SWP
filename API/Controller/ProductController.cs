using Application.Interface;
using Application.Request.Category;
using Application.Request.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> AddProductAsync(CreateProductRequest request)
        {
            var result = await _service.AddProductAsync(request);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategoryAsync()
        {
            var result = await _service.GetProductListAsync();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var result = await _service.DeleteByIdAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
