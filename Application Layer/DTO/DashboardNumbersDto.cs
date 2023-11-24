using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.DTO
{
    public class DashboardNumbersDto
    {
        public int TotalStudents { get; set; }
        public int TotalExams { get; set; }
        public int CompletedExams { get; set; }
        public int PassedExams { get; set; }
        public int FailedExams { get; set; }
    }

}
