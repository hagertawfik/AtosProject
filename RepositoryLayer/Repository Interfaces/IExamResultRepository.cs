using RepositoryLayer.Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository_Interfaces
{
    public interface IExamResultRepository
    {
        List<ExamResult> GetAllExamResults(int page, int pageSize);
        List<ExamResult> GetStudentExamHistory(string studentId, int page, int pageSize);

      //  bool Save();
        
    }
}
