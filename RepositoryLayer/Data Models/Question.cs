using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Data_Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public virtual ICollection<Choices> Choices { get; set; }

        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
    }
}
