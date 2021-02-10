using System.Collections.Generic;

namespace Questionnaire.Question
{
    public interface IQuestion
    {
        IEnumerable<IAnswerOptions> AnswerOptions { get; set; }
        string Text { get; set; }
        QuestionType QuestionType { get; set; }

        bool IsValid();
    }
}