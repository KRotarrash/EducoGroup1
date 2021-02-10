using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DbStuff.Model.Questionnaire
{
    public class QuestionAnswer : BaseModel
    {
        public virtual Answer Answer { get; set; }
        public virtual Question Question { get; set; }
    }
}
