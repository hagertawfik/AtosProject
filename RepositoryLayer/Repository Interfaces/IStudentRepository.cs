using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository_Interfaces
{
    public interface IStudentRepository
    {
         ICollection<Student> GetAllStudents(int page = 1, int pageSize = 10);
         Student GetStudentById(string id);
         bool UpdateStudent(Student student);
         bool Save();
        bool addStudentSubject(StudentSubject studentSubject);
        int totalStudentsNumber();

    }
}
