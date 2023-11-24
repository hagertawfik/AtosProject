using Application_Layer.BussinesLogicInterface;
using Application_Layer.DTO;
using AutoMapper;
using RepositoryLayer.Data_Models;
using RepositoryLayer.Repository_Interfaces;

namespace Application_Layer.BussinesLogic
{
    public class SubjectService:ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public SubjectService(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }
        public  List<SubjectDto> GetAllSubjects()
        {
            var subjects = _mapper.Map<List<SubjectDto>>(_subjectRepository.GetAllSubjects());
            return subjects;
          
        }



        public Response addSubject(SubjectRequestDto subjecdto)
        {
          
                var subjectFounded = _subjectRepository.GetAllSubjects().Where(c => c.Name.Trim().ToUpper() ==
                           subjecdto.Name.TrimEnd().ToUpper()).FirstOrDefault();
                if (subjectFounded != null)
                {
                    var response = new Response()
                    {
                        MyErrors = new List<string>()
                    {
                        "this Subject is already exist"
                    }
                    };
                    return response;
                }
                var subjectMap = _mapper.Map<Subject>(subjecdto);
                _subjectRepository.AddSubject(subjectMap);
                return new Response()
                {
                    Message = "subject added successfuly"
                };

            }


        public bool UpdateSubject(int id, SubjectRequestDto updatedSubjectDto)
        {
         
            var existingSubject =  _subjectRepository.GetSubjectById(id);

            if (existingSubject == null)
            {
               
                throw new Exception("Subject with this id  not found.");

            }

            existingSubject.Name = updatedSubjectDto.Name;

            return _subjectRepository.Update(existingSubject);
            
        }

    }

    }
