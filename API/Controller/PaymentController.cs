using Application.Interface;
using Application.Request.Payment;
using Application.Request.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        public IPaymentService _service;
        public PaymentController(IPaymentService service)
        {
            _service = service;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProcessPaymentAsync(PaymentRequest paymentRequest)
        {
            var result = await _service.ProcessPaymentAsync(paymentRequest, HttpContext);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
