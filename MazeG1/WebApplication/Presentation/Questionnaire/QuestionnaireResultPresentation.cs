using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model.Questionnaire;
using WebApplication.DbStuff.Repository.Questionnaire;

namespace WebApplication.Presentation.Questionnaire
{
    public class QuestionnaireResultPresentation
    {
        private QuestionnaireResultRepository _repository;
        public QuestionnaireResultPresentation(QuestionnaireResultRepository questionnaireResultRepository)
        {
            _repository = questionnaireResultRepository;
        }

        public void Save(QuestionnaireResult questionnaireResult)
        {
            _repository.Save(questionnaireResult);
        }
    }
}
