using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Questionnaire.Question;

namespace Questionnaire.Question
{
    public class Question : IQuestion
    {
        public string Text { get; set; }

        public QuestionType QuestionType { get; set; }

        public IEnumerable<IAnswerOptions> AnswerOptions { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Text))
            {
                return false;
            }

            switch (QuestionType)
            {
                case QuestionType.SingleAnswer:
                    return AnswerOptions.Count() > 1;
                case QuestionType.MultipleAnswer:
                    return AnswerOptions.Count() >= 1;
                default:
                    throw new Exception("Не известный тип QuestionType");
            }
        }
    }
}
