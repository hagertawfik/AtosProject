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
    public class SubjectRepository:ISubjectRepository
    {
        private readonly DataContext _context;
        public SubjectRepository(DataContext context)
        {
            _context = context;
        }
        public bool AddSubject(Subject subject)
        {
            _context.Add(subject);
            return Save();

        }

        public ICollection<Subject> GetAllSubjects()
        {
            return _context.Subjects.ToList();
        }

        public Subject GetSubjectById(int id)
        {
            return _context.Subjects.FirstOrDefault(s => s.SubjectId == id);
        }

        public string GetSubjectNameById(int id)
        {
            var subject =  _context.Subjects.FirstOrDefault(s => s.SubjectId == id);
            return subject.Name;
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }


        public bool Update(Subject subject)
        {
            _context.Update(subject);
            return Save();
        }
        
        public ICollection<Subject> GetStudentSubjects(string studentId)
        {
            return _context.Subjects.Where(su =>su.StudentSubjects.Any(st => st.UserId == studentId)).ToList();
        }

    }
}
