using DbFile.Model;
using DbFile.Model.QuestionnaireStuff;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbFile
{
    public class FileQuestionnaire : Repository<DbQuestionnaire>
    {
        protected override string FileName => "Questionnare.json";
    }
}
