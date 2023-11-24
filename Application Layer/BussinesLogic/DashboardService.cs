using Application_Layer.BussinesLogicInterface;
using Application_Layer.DTO;
using RepositoryLayer.Repository_Interfaces;

namespace Application_Layer.BussinesLogic
{
    public class DashboardService: IDashboardService
    {
        private readonly IExamRepository _examRepository;
        private readonly IStudentRepository _studentRepository;

        public DashboardService(IExamRepository examRepository, IStudentRepository studentRepository)
        {
            _examRepository = examRepository;
            _studentRepository = studentRepository;
        }

        public DashboardNumbersDto GetRequiredNumbers()
        {
            var totalStudents = _studentRepository.totalStudentsNumber();
            var totalExams = _examRepository.GetTotalExams();
            var completedExams = _examRepository.GetCompletedExams();
            var passedExams = _examRepository.GetPassedExams();
            var failedExams = _examRepository.GetFailedExams();

            return new DashboardNumbersDto
            {
                TotalStudents = totalStudents,
                TotalExams = totalExams,
                CompletedExams = completedExams,
                PassedExams = passedExams,
                FailedExams = failedExams
            };
        }

    }
}
