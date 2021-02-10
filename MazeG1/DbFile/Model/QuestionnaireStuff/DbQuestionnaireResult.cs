using Questionnaire.Answer;
using Questionnaire.Question;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbFile.Model.QuestionnaireStuff
{
    public class DbQuestionnaireResult : DbBaseModelQuestionnaire
    {
        public IQuestionnaireMain Questionnaire { get; set; }

        public IEnumerable<IQuestionResult> QuestionResults { get; set; }
    }
}
