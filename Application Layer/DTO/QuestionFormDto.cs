using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.DTO
{
    public class QuestionFormDto
    {
        public string questionText { get; set; }
        public List<string> choices { get; set; }
        public int correctAnswerIndex { get; set; }
    }
}
