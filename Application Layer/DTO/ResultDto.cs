using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.DTO
{
    public class ResultDto
    {
        public int ResultId { get; set; }
        public int Grade { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
    }
}
