using Application_Layer.BussinesLogicInterface;
using Application_Layer.DTO;
using RepositoryLayer.Repository_Interfaces;

namespace Application_Layer.BussinesLogic
{
    public class RequestExamService: IRequestExamSevice
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IStudentSubjectService _studentSubjectService;
        private readonly IExamRepository _examRepository;
        private readonly ICreateExamService _createExamService;

        public RequestExamService(IStudentRepository studentRepository, ISubjectRepository subjectRepository, IStudentSubjectService studentSubjectService, IExamRepository examRepository, ICreateExamService createExamService)
        {
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
            _studentSubjectService = studentSubjectService;
            _examRepository = examRepository;
            _createExamService  = createExamService;
        }

        public ResponseExamDto RequestExam(int subjectId, string studentId)
        {
            var subject = _subjectRepository.GetSubjectById(subjectId);
            var student = _studentRepository.GetStudentById(studentId);

            if (subject == null )
                throw new Exception("Subject not found");
            if (student == null) throw new Exception("Student not found");
          
            if (_studentSubjectService.IsStudentAssignToSubject(studentId, subjectId) == false)
                throw new Exception("Student not assign to this subject");
            _createExamService.CreateExam(subjectId);
           var exam =_examRepository.GetExam(subjectId);
            if (exam == null)
                throw new Exception("no exam generated");
           
            var questionWithChoices= _examRepository.GetQuestionsWithChoicesByExamId(exam.ExamId);

            var questionsWithChoicesDto = questionWithChoices.Select(q => new QuestionWithChoicesDto
            {
                QuestionId = q.QuestionId,
                QuestionText = q.QuestionText,
                Choices = q.Choices.Select(c => new ChioceDto
                {
                    ChoiceId = c.ChoiceId, 
                    ChoiceText = c.ChoiceText
                }).ToList()
            }).ToList();

            var examDto = new ResponseExamDto()
            {
                ExamId = exam.ExamId,
                SubjectId = subjectId,
                
                startDateTime = DateTime.Now,
                QuestionsWithChoices = questionsWithChoicesDto
            };

            //var

            return examDto;


        }

    }
    }
