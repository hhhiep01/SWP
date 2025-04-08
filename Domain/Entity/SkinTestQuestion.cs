using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class SkinTestQuestion : Base
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        //
        public ICollection<SkinTestAnswer>? SkinTestAnswers { get; set; }
    }
}
