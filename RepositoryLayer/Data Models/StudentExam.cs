using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace RepositoryLayer.Data_Models
{
    public class StudentExam
    {
        public int ExamId { get; set; }
        public string UserId { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual Student Student { get; set; }

    }
}
