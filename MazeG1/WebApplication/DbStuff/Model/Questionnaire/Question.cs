using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DbStuff.Model.Questionnaire
{
    public class Question : BaseModel
    {
        public virtual QuestionnaireModel Questionnaire { get; set; }
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public virtual List<QuestionnaireResult> QuestionnaireResults { get; set; } 
        public virtual List<QuestionAnswer> Answers { get; set; }
    }
    public enum QuestionType 
    {
        Single = 1,
        Multiple = 2
    }
}
