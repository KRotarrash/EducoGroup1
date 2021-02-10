using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model.Questionnaire;
using WebApplication.DbStuff.Repository.Questionnaire;

namespace WebApplication.Presentation.Questionnaire
{
    public class QuestionnaireRegistrationPresentation 
    {
        private QuestionnaireRegistrationRepository _repository;

        public QuestionnaireRegistrationPresentation(QuestionnaireRegistrationRepository questionnaireRegistrationRepository)
        {
            _repository = questionnaireRegistrationRepository;
        }

        public void Save(QuestionnaireRegistration questionnaireRegistration)
        {
            _repository.Save(questionnaireRegistration);
        }
    }
}
