using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DbStuff.Model.Questionnaire
{
    public class QuestionnaireResult : BaseModel
    {
        public virtual QuestionnaireRegistration QuestionnaireRegistration { get; set; }
        public virtual Question Question { get; set; }
        public virtual List<QuestionnaireResultDetail> QuestionnaireResultDetails { get; set; }
    }
}
