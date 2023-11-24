using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Data_Models
{
    public class Subject
    {
        
        public int SubjectId { get; set; }
        public string Name { get; set; }

       public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
