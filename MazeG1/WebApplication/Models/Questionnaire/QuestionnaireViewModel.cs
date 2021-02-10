using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model.Questionnaire;


namespace WebApplication.Models
{
    public class QuestionnaireViewModel
    {
        //public IQuestionnaireMain MQuestionnaire;
        public long Id { get; set; }
        public string Name { get; set; }
        public List<QuestionViewModel> Questions { get; set; }

        public QuestionnaireViewModel()
        {
            Questions = new List<QuestionViewModel>();
        }
    }
}
