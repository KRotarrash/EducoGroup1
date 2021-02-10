using System;
using System.Collections.Generic;
using System.Text;

namespace Questionnaire.Question
{
    public class AnswerOptions : IAnswerOptions
    {
        public string Text { get; set; }

        public bool IsValid()
        {
            return true;
        }
    }
}
