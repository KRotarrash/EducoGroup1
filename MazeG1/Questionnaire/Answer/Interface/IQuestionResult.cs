using Questionnaire.Question;
using System.Collections.Generic;

namespace Questionnaire.Answer
{
    public interface IQuestionResult
    {
        IEnumerable<IAnswerOptions> Answers { get; set; }
        IQuestion Question { get; set; }
    }
}