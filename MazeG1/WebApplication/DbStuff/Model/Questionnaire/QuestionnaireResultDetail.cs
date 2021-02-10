using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DbStuff.Model.Questionnaire
{
    public class QuestionnaireResultDetail : BaseModel
    {
        public virtual QuestionnaireResult QuestionnaireResult { get; set; }
        public virtual Answer Answer { get; set; }
    }
}
