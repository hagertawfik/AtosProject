using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Data_Models
{
    public class ExamConfiguration
    {
        public int ExamConfigurationId { get; set; }
        public int QuestionsNumber { get; set; }
        public DateTime ExamTime { get; set; }

    }
}
