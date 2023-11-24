using AutoMapper;
using Application_Layer.DTO;
using RepositoryLayer.Data_Models;
using System.Diagnostics.Metrics;

namespace APIs_layer.Helper.Mappers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Choices, ChioceDto>();
            CreateMap<ChioceDto, Choices>();
            CreateMap<Exam, ExamDto>();
            CreateMap<ExamDto, Exam>();
            CreateMap<Question, QuestionDto>();
            CreateMap<QuestionDto, Question>();
            CreateMap<ExamResult, ResultDto>();
            CreateMap<ResultDto, ExamResult>();
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
            CreateMap<Subject, SubjectDto>();
            CreateMap<SubjectDto, Subject>();
            CreateMap<Subject, SubjectRequestDto>();
            CreateMap<SubjectRequestDto, Subject>();
            CreateMap<ResponseExamDto, Exam>();
            CreateMap<Exam, ResponseExamDto>();
         
        }
        
    }
}
