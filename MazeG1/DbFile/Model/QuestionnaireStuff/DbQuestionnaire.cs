using System;
using System.Collections.Generic;
using System.Text;

namespace DbFile.Model.QuestionnaireStuff
{
    public class DbQuestionnaire : DbBaseModelQuestionnaire
    {
        public string Name { get; set; }

        public List<DbQuestion> Questions { get; set; }
    }
}
