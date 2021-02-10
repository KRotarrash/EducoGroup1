using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questionnaire.Question
{
    public class QuestionnaireMain : IQuestionnaireMain
    {
        public string Name { get; set; }
        public IEnumerable<IQuestion> Questions { get; set; }
        

        public bool IsValid()
        {
            if (Questions?.Count() <= 0)
            {
                return false;
            }

            return Questions.All(x => x.IsValid());
        }
    }
}
