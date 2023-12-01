using RepositoryLayer.Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository_Interfaces
{
    public interface ISubjectRepository
    {
        ICollection<Subject> GetAllSubjects();
        bool AddSubject(Subject subject);
         Subject GetSubjectById(int id);
         bool Save();
        bool Update(Subject subject);
        ICollection<Subject> GetStudentSubjects(string studentId);
        string GetSubjectNameById(int id);
    }
}
