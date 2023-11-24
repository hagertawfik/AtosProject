using Application_Layer.BussinesLogic;
using Application_Layer.DTO;

namespace Application_Layer.BussinesLogicInterface
{
    public interface ISubjectService
    {
         List<SubjectDto> GetAllSubjects();
         Response  addSubject(SubjectRequestDto subjecdto);
        bool UpdateSubject(int id, SubjectRequestDto updatedSubjectDto);
    }
}
