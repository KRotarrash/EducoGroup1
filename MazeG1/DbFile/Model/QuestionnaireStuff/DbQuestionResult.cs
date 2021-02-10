using Questionnaire.Question;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbFile.Model.QuestionnaireStuff
{
    public class DbQuestionResult : DbBaseModelQuestionnaire
    {
        public IQuestion Question { get; set; }

        public IEnumerable<IAnswerOptions> Answers { get; set; }
    }
}
