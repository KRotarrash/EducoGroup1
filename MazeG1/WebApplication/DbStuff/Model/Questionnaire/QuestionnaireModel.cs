using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DbStuff.Model.Questionnaire
{
    public class QuestionnaireModel : BaseModel
    {
        public string Name { get; set; }
        public virtual List<QuestionnaireRegistration> Registrations { get; set; }
        public virtual List<Question> Questions { get; set; }
    }
}
