using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Data_Models
{
    public class Student:IdentityUser
    {
        public string Gender { get; set; }
        public bool IsActive { get; set; }

        [MaxLength(30)]
        public string Stname { get; set; }
        public virtual ICollection<StudentExam> StudentExams { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
        public virtual ICollection<ExamResult> ExamResults { get; set; }


    }
}
