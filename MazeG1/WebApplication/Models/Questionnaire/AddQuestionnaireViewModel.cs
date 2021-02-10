using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class AddQuestionnaireViewModel
    {
        public long Id { get; set; }
        public string QuestionnaireName { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
        public string Answer { get; set; }
        public const int maxCountAnswer = 2;
        public const int maxCountQuestion = 5;
    }
}
