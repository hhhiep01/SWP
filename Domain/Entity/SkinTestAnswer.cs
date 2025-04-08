using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class SkinTestAnswer: Base
    {
        public int Id { get; set; }
        public SkinType AnswerLabel { get; set; }
        public string AnswerText { get; set; }
        //
        public SkinTestQuestion SkinTestQuestion { get; set; }
        public int SkinTestQuestionId { get; set; }
    }
}
