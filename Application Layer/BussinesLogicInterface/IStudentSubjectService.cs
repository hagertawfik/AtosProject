using Application_Layer.DTO;

namespace Application_Layer.BussinesLogicInterface
{
    public interface IStudentSubjectService
    {
        bool AddNewStudentSubject(string studentId, int subjectId);
        List<SubjectDto> GetStudentSubjects(string studentId);
        bool IsStudentAssignToSubject(string studentId, int subjectId);
    }
}
