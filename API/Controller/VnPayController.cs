using Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class VnPayController : ControllerBase
    {
        public IVnPayService _service { get; set; }
        public VnPayController(IVnPayService service)
        {
            _service = service;
        }

        [HttpGet("callback")]
        public async Task<IActionResult> PaymentCallback()
        {
            var response = await _service.PaymentExecute(Request.Query);

            // Redirect the user directly to the front-end with status
            if (response.IsSuccess)
            {
                // Extract the redirect URL from the response and pass it as a query parameter to the FE
                var redirectUrl = "https://jobsearch-zeta-nine.vercel.app/it-jobs?status=success";
                //var redirectUrl = "http://localhost:5173/it-jobs?status=success";
                return Redirect(redirectUrl);
            }
            else
            {
                var redirectUrl = "https://jobsearch-zeta-nine.vercel.app/it-jobs?status=failure";
                //var redirectUrl = "http://localhost:5173/it-jobs?status=success";
                return Redirect(redirectUrl);
            }
        }
    }
}
