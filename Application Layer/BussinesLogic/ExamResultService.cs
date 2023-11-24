using Application_Layer.BussinesLogicInterface;
using Application_Layer.DTO;
using RepositoryLayer.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.BussinesLogic
{
    public class ExamResultService:IExamResultService
    {
        private readonly IExamResultRepository _examResultRepository;

        public ExamResultService(IExamResultRepository examResultRepository)
        {
            _examResultRepository = examResultRepository;
        }

        public List<ExamHistoryDto> GetAllExamHistory(int page, int pageSize)
        {
            var examResults = _examResultRepository.GetAllExamResults(page, pageSize);

          
            var examHistoryList = examResults.Select(result => new ExamHistoryDto
            {
               
                StudentName = result.Student.Stname,
                Grade = result.Grade,
                StartTime = result.startTime,
                EndTime = result.endTime
            }).ToList();

            return examHistoryList;
        }


        public List<ExamHistoryDto> GetStudentExamHistory(string studentId, int page, int pageSize)
        {
            var examResults = _examResultRepository.GetStudentExamHistory(studentId,  page,  pageSize);

            
            var examHistoryList = examResults.Select(result => new ExamHistoryDto
            {
            
                StudentName = result.Student.Stname,
                Grade = result.Grade,
                StartTime = result.startTime,
                EndTime = result.endTime
            }).ToList();

            return examHistoryList;
        }
    }
}
