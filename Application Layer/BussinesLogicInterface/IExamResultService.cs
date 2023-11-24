using Application_Layer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.BussinesLogicInterface
{
    public interface IExamResultService
    {
        List<ExamHistoryDto> GetAllExamHistory(int page, int pageSize);
        List<ExamHistoryDto> GetStudentExamHistory(string studentId, int page, int pageSize);
    }
}
