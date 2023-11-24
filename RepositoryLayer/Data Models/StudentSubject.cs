using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Data_Models
{
    public class StudentSubject
    {
        public int SubjectId { get; set; }
        public string UserId { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Student Student { get; set; }
    }
}
