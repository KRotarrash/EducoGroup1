using System.Collections.Generic;
using WebApplication.DbStuff.Model.Questionnaire;

namespace WebApplication.Models
{
    public class QuestionViewModel
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public long AnswerChoiseId { get; set; }
        public List<AnswerViewModel> Answers { get; set; }
        public QuestionType Type { get; set; }
    }
}
