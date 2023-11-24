using Application_Layer.DTO;

namespace Application_Layer.BussinesLogicInterface
{
    public interface IQuestionsService
    {
        bool AddQuestionForm(int subjectId, QuestionFormDto questionFormDto);
    }
}
