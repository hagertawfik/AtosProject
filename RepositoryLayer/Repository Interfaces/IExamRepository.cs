using RepositoryLayer.Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository_Interfaces
{
    public interface IExamRepository
    {
        bool AddExam(Exam exam);
        bool Save();
        int GetTotalExams();
        public int GetCompletedExams();
        public int GetPassedExams();
        public int GetFailedExams();
        bool AddQuestionsExam(ExamQuestion examQuestion);
        Exam GetExam(int subjectId);
        List<Question> GetQuestionsWithChoicesByExamId(int examId);
       bool DeleteExam(Exam exam);
    }
}
