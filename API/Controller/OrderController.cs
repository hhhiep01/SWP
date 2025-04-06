using Application.Interface;
using Application.Request.Cart;
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
        public async Task<IActionResult> AddCategoryAsync()
        {
            var result = await _service.CreateOrderAsync();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
