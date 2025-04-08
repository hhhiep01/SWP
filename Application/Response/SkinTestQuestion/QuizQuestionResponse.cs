using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response.SkinTestQuestion
{
    public class QuizQuestionResponse
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public List<QuizAnswerResponse> Answers { get; set; }
    }
    public class QuizAnswerResponse
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public int AnswerLabel { get; set; }
    }
}
