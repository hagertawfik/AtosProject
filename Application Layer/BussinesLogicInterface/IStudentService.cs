using Application_Layer.DTO;

namespace Application_Layer.BussinesLogicInterface
{
    public interface IStudentService
    {

        List<StudentDto> GetAllStudents(int page, int pageSize);
        bool UpdateIsActive(string studentId, bool isActive);
   

    }
}
