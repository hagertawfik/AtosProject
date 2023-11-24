using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.DTO
{
    public class ResponseExamDto
    {
        public int ExamId { get; set; }
        public int SubjectId { get; set; }
        //public int StudentId { get; set; }
        public  DateTime startDateTime { get; set; }
        public List<QuestionWithChoicesDto> QuestionsWithChoices { get; set; }

    }
}
