using System.Collections.Generic;

namespace Questionnaire.Question
{
    public interface IQuestionnaireMain
    {
        IEnumerable<IQuestion> Questions { get; set; }

        bool IsValid();
    }
}