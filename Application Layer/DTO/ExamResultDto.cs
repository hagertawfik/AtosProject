using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.DTO
{
    public class ExamResultDto
    {
        public int Grade { get; set; }
        public DateTime endTime { get; set; }
        public DateTime startTime { get; set; } 
        public int ExamId { get; set; }
        public string StudentId { get; set; }
        
    }
}
