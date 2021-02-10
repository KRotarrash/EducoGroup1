using Questionnaire.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questionnaire.Answer
{
    public class QuestionResult : IQuestionResult
    {
        public IQuestion Question { get; set; }

        public IEnumerable<IAnswerOptions> Answers { get; set; }

        public bool IsValidAnswer()
        {
            switch (Question.QuestionType)
            {
                case QuestionType.SingleAnswer:
                    return Answers.Count() == 1;
                case QuestionType.MultipleAnswer:
                    return Question.AnswerOptions.Count() >= Answers.Count();
                default:
                    throw new Exception($"Что то за тип? {Question.QuestionType}");
            }
        }
    }
}
