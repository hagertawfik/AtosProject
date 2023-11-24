using Application_Layer.BussinesLogicInterface;
using Application_Layer.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Data_Models;
using RepositoryLayer.Repository_Interfaces;
using System.Collections.Generic;

namespace Application_Layer.BussinesLogic
{
    public class CreateExamService : ICreateExamService
    {

        private readonly ISubjectRepository _subjectRepository;
        private readonly IExamRepository _examRepository;
        private readonly IQuestionRepository _questionRepository;
      

        public CreateExamService(ISubjectRepository subjectRepository, IExamRepository examRepository, IQuestionRepository questionRepository)
        {
            _subjectRepository = subjectRepository;
            _examRepository = examRepository;
            _questionRepository = questionRepository;
            

        }

        public void CreateExam(int subjectId)
        {
            var subject = _subjectRepository.GetSubjectById(subjectId);
            if (subject == null)
                throw new Exception("Subject not found.");

            var questionIds = _questionRepository.GetRandomIdQuestion(subjectId);

            if (questionIds == null || !questionIds.Any())
                throw new Exception("No questions found for the subject");

            var exam = new Exam()
            {
              
                Subject = subject,
            };

            if (_examRepository.AddExam(exam) == null)
                throw new Exception("Exam does not added");

            var questionsAdded = 0;

            foreach (var questionId in questionIds)
            {
                var question = _questionRepository.FindQuestionById(questionId);
                if (question != null)
                {
                    var examQuestion = new ExamQuestion
                    {
                        ExamId = exam.ExamId,
                        Exam = exam,
                        QuestionId = questionId,
                        Question = question
                    };

                    if (_examRepository.AddQuestionsExam(examQuestion))
                    {
                        questionsAdded++;
                    }
                    else
                    {
                        throw new Exception("Questions could not be added to the exam.");
                    }
                }
                else
                {
                    throw new Exception("Question not found.");
                }
            }

            if (questionsAdded == 0)
            {
              
                _examRepository.DeleteExam(exam); 
                throw new Exception("No questions were added to the exam. Exam creation rolled back.");
            }
        }

    }
    }


    






