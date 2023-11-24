using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Data_Models;
using RepositoryLayer.Database_Context;
using RepositoryLayer.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository_Implementations
{
    public class ExamResultRepository: IExamResultRepository
    {
        private readonly DataContext _context;
      

        public ExamResultRepository(DataContext context)
        {
            _context = context;
        
            
        }
     
        public List<ExamResult> GetAllExamResults(int page, int pageSize)
        {
        
            var examResultsList = _context.ExamResults
             .Include(re => re.Exam)
             .Include(re => re.Student)
             .ToList();
            var totalCount = examResultsList.Count();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);
            var examResultsPerPage = examResultsList.Skip(page - 1).Take(pageSize).ToList();
            return examResultsPerPage;
        }

        public List<ExamResult> GetStudentExamHistory(string studentId, int page, int pageSize)
        {
            var examStudentResultsList = _context.ExamResults
                .Include(re => re.Exam)
                .Include(re => re.Student)
                .Where(re => re.UserId == studentId)
                .ToList();
            var totalCount = examStudentResultsList.Count();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);
            var examResultsPerPage = examStudentResultsList.Skip(page - 1).Take(pageSize).ToList();
            return examResultsPerPage;
        }
    }
}
