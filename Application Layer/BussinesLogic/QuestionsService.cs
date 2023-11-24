using Application_Layer.BussinesLogicInterface;
using Application_Layer.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Data_Models;
using RepositoryLayer.Repository_Interfaces;

namespace Application_Layer.BussinesLogic
{
    public class QuestionsService: IQuestionsService
    {

        private readonly ISubjectRepository _subjectRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IChoiceRepository _choiceRepository;
        
        public QuestionsService(ISubjectRepository subjectRepository, 
            IQuestionRepository questionRepository, IChoiceRepository choiceRepository )
        {
            _subjectRepository = subjectRepository;
            _questionRepository = questionRepository;
            _choiceRepository = choiceRepository;
            
        }

        public bool AddQuestionForm(int subjectId, QuestionFormDto questionFormDto)
        {
            var subject = _subjectRepository.GetSubjectById(subjectId);
            if (subject == null)
            {
                throw new Exception("this Subject not found");
            }

   
            var question = new Question
            {

                QuestionText = questionFormDto.questionText,
                Subject = subject,
               
            };

            if (!_questionRepository.AddQuestion(question))
                throw new Exception("The question has not been added ");

        
            for (int i = 0; i < questionFormDto.choices.Count; i++)
            {
                var isCorrectAnswerflag = false;
                if (i == questionFormDto.correctAnswerIndex)
                {
                    isCorrectAnswerflag = true;
                };

                var choice = new Choices
                {
                    Question = question,
                    ChoiceText = questionFormDto.choices[i],
                    IsCorrect = isCorrectAnswerflag
                };
                if (!_choiceRepository.AddChoices(choice))
                    throw new Exception("The choices has not been added ");
                
            }
            
            return true;
        }


     

    }
}
