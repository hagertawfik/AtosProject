using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Data_Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Database_Context
{
    public class DataContext : IdentityDbContext<Student>
    {
         public DataContext(DbContextOptions<DataContext> options) : base(options)
        {  
        }
        public DbSet<Choices> Choices { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentExam> StudentExams { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<ExamConfiguration> ExamConfigurations { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            // ExamQuestion many to many relation
            modelBuilder.Entity<ExamQuestion>()
                  .HasKey(pc => new { pc.ExamId, pc.QuestionId });
            modelBuilder.Entity<ExamQuestion>()
                .HasOne(p => p.Exam)
                .WithMany(pc => pc.ExamQuestions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasForeignKey(p => p.ExamId);
             

            modelBuilder.Entity<ExamQuestion>()
               .HasOne(p => p.Question)
               .WithMany(pc => pc.ExamQuestions)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasForeignKey(c => c.QuestionId);

            //StudentExam many to many relation
            modelBuilder.Entity<StudentExam>()
                  .HasKey(pc => new { pc.ExamId, pc.UserId });
            modelBuilder.Entity<StudentExam>()
                .HasOne(p => p.Exam)
                .WithMany(pc => pc.StudentExams)
                .HasForeignKey(p => p.ExamId);
            modelBuilder.Entity<StudentExam>()
               .HasOne(p => p.Student)
               .WithMany(pc => pc.StudentExams)
               .HasForeignKey(c => c.UserId);


            // StudentSubject many to many relation
            modelBuilder.Entity<StudentSubject>()
                  .HasKey(pc => new { pc.SubjectId, pc.UserId });
            modelBuilder.Entity<StudentSubject>()
                .HasOne(p => p.Subject)
                .WithMany(pc => pc.StudentSubjects)
                .HasForeignKey(p => p.SubjectId);
            modelBuilder.Entity<StudentSubject>()
               .HasOne(p => p.Student)
               .WithMany(pc => pc.StudentSubjects)
               .HasForeignKey(c => c.UserId);


            // one to many relation Subject and Exam
            modelBuilder.Entity<Subject>()
             .HasMany(s => s.Exams)            // Subject has many Exams
             .WithOne(e => e.Subject)          // Exam has one Subject
             .HasForeignKey(e => e.SubjectId); // Define the foreign key property

            // one to many relation Subject and Question
            modelBuilder.Entity<Subject>()
             .HasMany(s => s.Questions)            // Subject has many Exams
             .WithOne(e => e.Subject)          // Exam has one Subject
             .HasForeignKey(e => e.SubjectId); // Define the foreign key property

            // one to many relation question and Choices
            modelBuilder.Entity<Question>()
             .HasMany(s => s.Choices)            // question has many Choices
             .WithOne(e => e.Question)          // Choices has one question
             .HasForeignKey(e => e.QuestionId); // Define the foreign key property

            // one to many relation Exam and Result
            modelBuilder.Entity<Exam>()
             .HasMany(s => s.ExamResults)            // Exam has many Result
             .WithOne(e => e.Exam)          // Result has one Exam
             .HasForeignKey(e => e.ExamId); // Define the foreign key property


            // one to many relation user and Result
            modelBuilder.Entity<Student>()
             .HasMany(s => s.ExamResults)            // user has many Result
             .WithOne(e => e.Student)          // Result has one user
             .HasForeignKey(e => e.UserId); // Define the foreign key property

           base.OnModelCreating(modelBuilder);



        }
      


    }
}
