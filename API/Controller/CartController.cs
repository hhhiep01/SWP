using Application.Interface;
using Application.Request.Cart;
using Application.Request.CartItem;
using Application.Request.Category;
using Application.Services;
using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public ICartService _service;
        public CartController(ICartService service)
        {
            _service = service;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync(AddToCartRequest request)
        {
            var result = await _service.AddToCartAsync(request);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCartAsync()
        {
            var result = await _service.GetCartAsync();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [Authorize]
        [HttpDelete("remove-item/{productId}")]
        public async Task<IActionResult> RemoveCartItem(int productId)
        {
            var result = await _service.RemoveCartItemAsync(productId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [Authorize]
        [HttpPut("update-item")]
        public async Task<IActionResult> UpdateCartItem(UpdateCartItemRequest request)
        {
            var result = await _service.UpdateCartItemAsync(request);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
