//using Application_Layer.BussinesLogicInterface;
//using Application_Layer.DTO;
//using AutoMapper;
//using Microsoft.Identity.Client;
//using RepositoryLayer.Data_Models;
//using RepositoryLayer.Repository_Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application_Layer.BussinesLogic
//{
//    public class SubmitExamService: ISubmitExamService
//    {
//        private readonly ISubmitExamRepository _submitExamRepository;
       

//        public SubmitExamService(ISubmitExamRepository submitExamRepository)
//        {
          
//            _submitExamRepository = submitExamRepository;
//        }
//        public int SubmitExam(SubmitExamRequestDto submitExamDto)
//        {
           
//            var totalCorrectAnswer = 0;

//            foreach (var choice in submitExamDto.SelectedChoices)
//            {
//                var correctChoiceId = _submitExamRepository.GetCorrectChoiceId(choice.QuestionId);
//                if (choice.ChoiceId == correctChoiceId)
//                {
//                    totalCorrectAnswer++;

//                }
//            }
//           return totalCorrectAnswer;

//        }
//    }
//}
