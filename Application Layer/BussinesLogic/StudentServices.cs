using Application_Layer.BussinesLogicInterface;
using Application_Layer.DTO;
using AutoMapper;
using RepositoryLayer.Repository_Interfaces;

namespace Application_Layer.BussinesLogic
{
    public class StudentServices:IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentServices(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

   
        public  List<StudentDto> GetAllStudents(int page , int pageSize)
        {
            var students = _mapper.Map<List<StudentDto>>(_studentRepository.GetAllStudents(page, pageSize));

           return   students;
        }

        public bool UpdateIsActive(string studentId, bool isActive)
        {
         
            var student = _studentRepository.GetStudentById(studentId);

            if (student == null)
            {
                throw new Exception($"Student with id {studentId} does not exist");
               
               
            }
            student.IsActive = isActive;
            return _studentRepository.UpdateStudent(student);
       

        }


    }
}
