using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Data_Models;
using RepositoryLayer.Database_Context;
using RepositoryLayer.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository_Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;
        private readonly UserManager<Student> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public StudentRepository(DataContext context , UserManager<Student> userManager , RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;

        }
        public ICollection<Student> GetAllStudents(int page, int pageSize)
        {
            var students = _context.Users.ToList();
            var totalCount = students.Count();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);
            var studentsPerPage = students.Skip(page - 1).Take(pageSize).ToList();
            return studentsPerPage ;
        }

        public Student GetStudentById(string id)
        {
            return _context.Users.FirstOrDefault(s => s.Id == id);
        }


        public bool UpdateStudent(Student student)
        {
            _context.Update(student);
            return Save();
        }


        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool addStudentSubject(StudentSubject studentSubject)
        {
            _context.StudentSubjects.Add(studentSubject);
            return Save();

        }


        public int totalStudentsNumber()
        {
            var students = _userManager.GetUsersInRoleAsync("student").Result;
            return students.Count();
        }

    }

    }




