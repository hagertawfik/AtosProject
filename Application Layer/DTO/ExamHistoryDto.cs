using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.DTO
{
    public class ExamHistoryDto
    {
        public string ExamName { get; set; }
        public string StudentName { get; set; }
      //  public string SubjectName { get; set; }
        public int Grade { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

       
    }
}
