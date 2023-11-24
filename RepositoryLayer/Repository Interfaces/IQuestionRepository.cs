using RepositoryLayer.Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository_Interfaces
{
    public interface IQuestionRepository
    {
        bool AddQuestion(Question question);
        bool Save();
        // ICollection<Question> GetRandomQuestionsBySubjectId(int subjectId, int count);
        IEnumerable<Question> GetAllQuestionsBySubjectId(int subjectId);
        IEnumerable<int> GetRandomIdQuestion( int subjectId);
        Question FindQuestionById(int questionId);

    }
}
