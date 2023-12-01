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
    public class ExamRepository : IExamRepository
    {
        private readonly DataContext _context;

        public ExamRepository(DataContext dbContext)
        {
            _context = dbContext;
        }

        public bool AddExam(Exam exam)
        {
            _context.Exams.Add(exam);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public int GetTotalExams()
        {
            return _context.Exams.Count();
        }

        public int GetCompletedExams()
        {
            var completedExamsCount = _context.ExamResults
                .Select(r => r.ExamId)
                .Distinct()
                .Count();

            return completedExamsCount;
        }

        public int GetPassedExams()
        {
            var questionsNumber = _context.ExamConfigurations.Sum(ec => ec.QuestionsNumber);
            var passedExamsCount = _context.ExamResults
                .Count(r => r.Grade > 0.5 * questionsNumber);

            return passedExamsCount;
        }

        public int GetFailedExams()
        {
            var questionsNumber = _context.ExamConfigurations.Sum(ec => ec.QuestionsNumber);

            var failedExamsCount = _context.ExamResults
                .Count(r => r.Grade < 0.5 * questionsNumber);

            return failedExamsCount;
        }

        public bool AddQuestionsExam(ExamQuestion examQuestion)
        {
            _context.ExamQuestions.Add(examQuestion);
            return Save();

        }


        public Exam GetExam(int subjectId)
        {
            Random random = new Random();
            var examsForSubject = _context.Exams.Where(x => x.SubjectId == subjectId).ToList();
            if (examsForSubject.Any())
            {
                int randomIndex = random.Next(0, examsForSubject.Count);
                return examsForSubject[randomIndex];
            }

            return null;
        }


        public List<Question> GetQuestionsWithChoicesByExamId(int examId)
        {
            var questionsWithChoices = _context.ExamQuestions
                .Where(eq => eq.ExamId == examId)
                .Join(
                    _context.Questions.Include(q => q.Choices),
                    eq => eq.QuestionId,
                    q => q.QuestionId,
                    (eq, q) => q
                )
                .Distinct()
                .ToList();

            return questionsWithChoices;
        }

        public bool DeleteExam(Exam exam)
        {
            try
            {
                _context.Exams.Remove(exam);
                return Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete exam: {ex.Message}");
                return false;
            }
        }



    }

}
