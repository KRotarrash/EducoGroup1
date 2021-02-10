using Questionnaire.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questionnaire.Answer
{
    public class QuestionnaireResult : IQuestionnaireResult
    {
        public IQuestionnaireMain Questionnaire { get; set; }

        public IEnumerable<IQuestionResult> QuestionResults { get; set; }

        public bool IsFullResult()
        {
            return Questionnaire.Questions.Count() == QuestionResults.Count();
        }
    }
}
