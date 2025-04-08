using Application.Interface;
using Application.Request.Cart;
using Application.Request.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public IOrderService _service;
        public OrderController(IOrderService service)
        {
            _service = service;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync(CreateOrderRequest createOrderRequest)
        {
            var result = await _service.CreateOrderAsync(createOrderRequest);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllOrderAsync()
        {
            var result = await _service.GetAllOrderAsync();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
