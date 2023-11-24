using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Data_Models;
using RepositoryLayer.Database_Context;
using RepositoryLayer.Repository_Interfaces;
using System.Linq;

namespace RepositoryLayer.Repository_Implementations
{
    public class QuestionRepository:IQuestionRepository
    {
        private readonly DataContext _context;

        public QuestionRepository(DataContext dbContext)
        {
            _context = dbContext;
        }

        public bool AddQuestion(Question question)
        {
            _context.Questions.Add(question);
            return Save();
        }
       
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public IEnumerable<Question> GetAllQuestionsBySubjectId(int subjectId)
        {

            var questions = _context.Questions
                .Where(q => q.SubjectId == subjectId)
                .Include(q => q.Choices)
                .ToList();

            return questions;
        }

        public IEnumerable<int> GetRandomIdQuestion(int subjectId)
        {
           // var numberOfQuestionsByExam = _context.ExamConfigurations.Sum(ec => ec.QuestionsNumber);
            int numberOfQuestionsByExam = 5;
          var  questions = GetAllQuestionsBySubjectId(subjectId);
            if(questions.Count()< numberOfQuestionsByExam) { throw new Exception("the number of question not enough to generate exam"); }
            Random random = new Random();
            IEnumerable<int> questionIds = questions
                .OrderBy(q => random.Next())
                .Select(q => q.QuestionId)
                .Take(numberOfQuestionsByExam)
                .ToList();
            return questionIds;
        }
            
        public Question FindQuestionById(int questionId)
        {
         return _context.Questions.Find(questionId); 
                   
        }
       
     


    }
}
