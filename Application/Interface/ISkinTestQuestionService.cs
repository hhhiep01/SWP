using Application.Request.SkinTestQuestion;
using Application.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ISkinTestQuestionService
    {
        Task<ApiResponse> CreateQuestion(CreateQuizQuestionRequest request);
        Task<ApiResponse> GetAllQuestions();
    }
}
