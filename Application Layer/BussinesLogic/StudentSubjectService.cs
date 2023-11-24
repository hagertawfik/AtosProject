using Application_Layer.BussinesLogicInterface;
using Application_Layer.DTO;
using AutoMapper;
using RepositoryLayer.Data_Models;
using RepositoryLayer.Repository_Interfaces;

namespace Application_Layer.BussinesLogic
{
    public class StudentSubjectService: IStudentSubjectService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;
        public StudentSubjectService(IStudentRepository studentRepository, ISubjectRepository subjectRepository, IMapper mapper )
        {
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
           _mapper = mapper;
          
        }
        public bool AddNewStudentSubject(string studentId, int subjectId)
        {
            var subject = _subjectRepository.GetSubjectById(subjectId);
            if (subject == null) { throw new Exception($"subject with id {subjectId} does not exist"); }
            var student = _studentRepository.GetStudentById(studentId);
            if (student == null) { throw new Exception($"Student with id {studentId} does not exist");}
            var studentSubject = new StudentSubject
            {
                Student = student,
                Subject = subject
            };
          return  _studentRepository.addStudentSubject(studentSubject);

        }


        public List<SubjectDto> GetStudentSubjects(string studentId)
        {
            var student = _studentRepository.GetStudentById(studentId);
            if (student == null)
            {
                throw new Exception($"Student with id {studentId} does not exist");
            }
            var subjects = _mapper.Map<List<SubjectDto>>(_subjectRepository.GetStudentSubjects(studentId));
            return subjects;
         
        }

        public bool IsStudentAssignToSubject(string studentId, int subjectId)
        {
            var studentSubjects = GetStudentSubjects(studentId);
           return studentSubjects.Any(su => su.SubjectId == subjectId); 
        }

    }
}
