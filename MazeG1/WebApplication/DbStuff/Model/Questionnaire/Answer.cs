using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DbStuff.Model.Questionnaire
{
    public class Answer : BaseModel
    {
        public string Text { get; set; }
        public virtual List<QuestionnaireResultDetail> QuestionnaireReultDetails { get; set; }
        public virtual List<QuestionAnswer> Questions { get; set; }
    }
}
