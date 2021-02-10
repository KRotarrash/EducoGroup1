using MazeG1.Question;
using Questionnaire.Answer;
using Questionnaire.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bot = MazeG1.Question.RandomAnswerBot;

namespace Questionnaire
{
    public class QuestionaryStart
    {
        public string StartQ()
        {
            //Анкета
            var bot = new RandomAnswerBot(); //не видит бота, не понимаю почему ссылка не работает
            var questionnaire = bot.GenerateQuestionnaire();

            var list = new List<QuestionnaireResult>();
            for (int i = 0; i < 10; i++)
            {
                var result = bot.GenerateResult(questionnaire);
                list.Add(result);
            }

            foreach (var questionnaireResult in list)
            {
                questionnaireResult
                    .QuestionResults
                    .OrderBy(x => x.Answers.Count())
                    .Where(x =>
                        x.Question.QuestionType == QuestionType.MultipleAnswer)
                    .ToList().ForEach(x =>
                    {
                        Console.WriteLine(x.Question.Text);
                        x.Answers.ToList()
                            .ForEach(x => Console.WriteLine($"\t{x.Text}"));
                    });
            }
            return null;
        }
    }
}
