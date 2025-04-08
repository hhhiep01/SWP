using Application.Interface;
using Application.Request.Product;
using Application.Request.SkinTestQuestion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkinTestQuestionController : ControllerBase
    {

        public ISkinTestQuestionService _service;
        public SkinTestQuestionController(ISkinTestQuestionService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> AddProductAsync(CreateQuizQuestionRequest request)
        {
            var result = await _service.CreateQuestion(request);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            var result = await _service.GetAllQuestions();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
