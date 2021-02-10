using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model.Questionnaire;
using WebApplication.DbStuff.Repository.Questionnaire;
using WebApplication.Models;
using WebApplication.Service;

namespace WebApplication.Presentation.Questionnaire
{
    public class QuestionnairePresentation
    {
        private IQuestionnaireModelRepository _questionnaireRepository;
        private IQuestionnaireRegistrationRepository _registrationRepository;
        private IQuestionnaireResultRepository _resultRepository;
        private IQuestionnaireResultDetailRepository _resultDetailRepository;
        private IQuestionRepository _questionRepository;
        private IAnswerRepository _answerRepository;
        private IQuestionAnswerRepository _questionAnswerRepository;
        private IUserService _userService;


        public QuestionnairePresentation(IQuestionnaireModelRepository questionnaireModelRepository,
                                         IQuestionnaireRegistrationRepository questionnaireRegistrationRepository,
                                         IQuestionnaireResultRepository questionnaireResultRepository,
                                         IQuestionnaireResultDetailRepository questionnaireResultDetailRepository,
                                         IQuestionRepository questionRepository,
                                         IAnswerRepository answerRepository,
                                         IQuestionAnswerRepository questionAnswerRepository,
                                         IUserService userService)
        {
            _questionnaireRepository = questionnaireModelRepository;
            _registrationRepository = questionnaireRegistrationRepository;
            _resultRepository = questionnaireResultRepository;
            _resultDetailRepository = questionnaireResultDetailRepository;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _questionAnswerRepository = questionAnswerRepository;
            _userService = userService;
        }

        public ResultViewModel GetResultViewModel()
        {
            return new ResultViewModel() {
                Registrations = _userService.GetCurrentUser().QuestionnaireRegistrations
            };
        }

        public void SaveQuestionnaire(QuestionnaireViewModel model)
        {
            var registration = new QuestionnaireRegistration
            {
                Questionnaire = _questionnaireRepository.Get(model.Id),
                User = _userService.GetCurrentUser()
            };

            _registrationRepository.Save(registration);

            foreach (var question in model.Questions)
            {
                QuestionnaireResult result = new QuestionnaireResult
                {
                    QuestionnaireRegistration = registration,
                    Question = _questionRepository.Get(question.Id)
                };
                _resultRepository.Save(result);

                switch (question.Type)
                {
                    case QuestionType.Single:

                        var resultDetailSingle = new QuestionnaireResultDetail() {
                            QuestionnaireResult = result,
                            Answer = _answerRepository.Get(question.AnswerChoiseId)
                };
                        _resultDetailRepository.Save(resultDetailSingle);
                        break;

                    case QuestionType.Multiple:
                        foreach (var answer in question.Answers)
                        {
                            if (answer.IsChecked)
                            {
                                var resultDetailMultiple = new QuestionnaireResultDetail() {
                                    QuestionnaireResult = result,
                                    Answer = _answerRepository.Get(answer.Id)
                                };

                                _resultDetailRepository.Save(resultDetailMultiple);
                            }
                        }
                        break;
                }
            }
        }

        public void NewQuestionnaireSave(AddQuestionnaireViewModel model)
        {
            var questionnaireModel = new QuestionnaireModel()
            {
                Name = model.QuestionnaireName,
            };
            _questionnaireRepository.Save(questionnaireModel);

            foreach (var questionview in model.Questions)
            {
                if (questionview.Text != null)
                {
                    var question = new Question()
                    {
                        Questionnaire = questionnaireModel,
                        Text = questionview.Text,
                        Type = questionview.Type,
                        Answers = new List<QuestionAnswer>(),
                    };

                    foreach (var ansewerview in questionview.Answers)
                    {
                        if (ansewerview.Text != null)
                        {
                            var answer = new Answer()
                            {
                                Text = ansewerview.Text,
                            };

                            var questionAnswer = new QuestionAnswer()
                            {
                                Question = question,
                                Answer = answer
                            };

                            question.Answers.Add(questionAnswer);
                        }
                    }
                    _questionRepository.Save(question);

                }
            }
        }

        public QuestionnaireViewModel GetQuestionnaireViewModel(long id)
        {
            return new QuestionnaireViewModel()
            {
                Id = id,
                Name = _questionnaireRepository.Get(id).Name,
                Questions = QuestionDbToViewModel(_questionnaireRepository.Get(id).Questions)
            };
        }

        public ManageQuestionnairesViewModel GetManageQuestionnairesViewModel()
        {
            return new ManageQuestionnairesViewModel()
            {
                Questionnaires = _questionnaireRepository.GetAll().ToList()
            };
        }

        private List<QuestionViewModel> QuestionDbToViewModel(List<Question> questions)
        {
            List<QuestionViewModel> viewQuestions = new List<QuestionViewModel>();
            foreach (Question question in questions)
            {
                QuestionViewModel viewQuestion = new QuestionViewModel();
                viewQuestion.Id = question.Id;
                viewQuestion.Text = question.Text;
                viewQuestion.Type = question.Type;
                viewQuestion.Answers = new List<AnswerViewModel>();
                //foreach (var answer in question. QuestionAnswers)  
                foreach (var answer in question.Answers)    //работает
                {
                    viewQuestion.Answers.Add(AnswerDbToViewModel(answer.Answer));
                }
                viewQuestions.Add(viewQuestion);
            }

            return viewQuestions;
        }

        private AnswerViewModel AnswerDbToViewModel(Answer answer)        {
           
                AnswerViewModel viewAnswer = new AnswerViewModel();
                viewAnswer.Id = answer.Id;
                viewAnswer.Text = answer.Text; 
            return viewAnswer;
        }

    }  
}
