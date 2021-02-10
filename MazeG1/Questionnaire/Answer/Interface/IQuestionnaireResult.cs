using Questionnaire.Question;
using System.Collections.Generic;

namespace Questionnaire.Answer
{
    public interface IQuestionnaireResult
    {
        IQuestionnaireMain Questionnaire { get; set; }
        IEnumerable<IQuestionResult> QuestionResults { get; set; }

        bool IsFullResult();
    }
}