using Questionnaire.Question;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbFile.Model.QuestionnaireStuff
{
    public class DbQuestion : DbBaseModelQuestionnaire
    {
        public string Text { get; set; }
        public QuestionType QuestionType { get; set; }

        public List<DbAnswerOptions> AnswerOptions { get; set; }

    }
}
