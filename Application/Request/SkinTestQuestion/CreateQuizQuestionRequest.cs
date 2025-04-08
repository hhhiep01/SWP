using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request.SkinTestQuestion
{
    public class CreateQuizQuestionRequest
    {
        public string QuestionText { get; set; }  
        public List<CreateQuizAnswerRequest> Answers { get; set; } 
    }
    public class CreateQuizAnswerRequest
    {
        public string AnswerText { get; set; }  
        public SkinType AnswerLabel { get; set; }  
    }
}
