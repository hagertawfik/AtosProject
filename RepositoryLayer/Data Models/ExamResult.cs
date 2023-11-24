using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Data_Models
{
    public class ExamResult
    {
        [Key]
        public int ExamResultId { get; set; }
        public int Grade { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
         public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }
        public string UserId { get; set; }
        public virtual Student Student { get; set; }


    }
}
