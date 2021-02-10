using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DbStuff.Model.Questionnaire
{
    public class QuestionnaireRegistration : BaseModel
    {
        public virtual SpecialUser User { get; set; }
        public virtual QuestionnaireModel Questionnaire { get; set; }
        public DateTime Date { get; set; }
        public  virtual List<QuestionnaireResult> QuestionnaireResults { get; set; }
        public QuestionnaireRegistration()
        {
            Date = DateTime.Now;
        }
    }
}
