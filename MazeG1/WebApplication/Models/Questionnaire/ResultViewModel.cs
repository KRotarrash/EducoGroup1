using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model.Questionnaire;

namespace WebApplication.Models
{
    public class ResultViewModel
    {
        public List<QuestionnaireRegistration> Registrations { get; set; }
        public List<ResultViewModel> Results { get; set; }
    }
}
