using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Data_Models
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }
        //public string ExamName { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public virtual ICollection<ExamResult>   ExamResults  { get; set; }
        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
        public virtual ICollection<StudentExam> StudentExams { get; set; }


    }
}
