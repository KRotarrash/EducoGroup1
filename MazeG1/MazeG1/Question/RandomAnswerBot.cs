using Questionnaire.Answer;
using Questionnaire.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuestionLogic = Questionnaire.Question.Question;

namespace MazeG1.Question
{
    public class RandomAnswerBot
    {
        private Random _random => new Random();

        public QuestionnaireMain GenerateQuestionnaire() {
            var questionnaire = new QuestionnaireMain()
            {
                Name = "Test"
            };
            var listQuestions  = new List<QuestionLogic>();
            for (int k = 0; k < 5; k++)
            {
                var question = new QuestionLogic()
                {
                    QuestionType =
                        k % 2 == 0
                            ? QuestionType.MultipleAnswer
                            : QuestionType.SingleAnswer,
                    Text = $"How do you do? {k}"
                };
                var listAnswer = new List<AnswerOptions>();
                for (int i = 0; i < 3; i++)
                {
                    var answerOption = new AnswerOptions()
                    {
                        Text = $"well {i}"
                    };
                    listAnswer.Add(answerOption);
                }
                question.AnswerOptions = listAnswer;
                listQuestions.Add(question);
            }
            
            questionnaire.Questions = listQuestions;

            return questionnaire;
        }

        public QuestionnaireResult GenerateResult(QuestionnaireMain questionnaire)
        {
            var result = new QuestionnaireResult();
            result.Questionnaire = questionnaire;
            var questionResults = new List<QuestionResult>();

            foreach (var question in questionnaire.Questions)
            {
                var questionResult = GenerateOneAsnwer(question);
                questionResults.Add(questionResult);
            }

            result.QuestionResults = questionResults;

            return result;
        }

        public QuestionResult GenerateOneAsnwer(IQuestion question)
        {
            var questionResult = new QuestionResult();
            questionResult.Question = question;
            var answers = new List<IAnswerOptions>();
            switch (question.QuestionType)
            {
                case QuestionType.SingleAnswer:
                    var randomAnswer = GetRandomElemFromArray(question.AnswerOptions);
                    answers.Add(randomAnswer);
                    break;
                case QuestionType.MultipleAnswer:
                    var randomAnswerOne = GetRandomElemFromArray(question.AnswerOptions);
                    answers.Add(randomAnswerOne);
                    
                    var copy = question.AnswerOptions.ToList();
                    copy.Remove(randomAnswerOne);

                    var randomAnswerTwo = GetRandomElemFromArray(copy);
                    answers.Add(randomAnswerTwo);
                    break;
                default:
                    throw new Exception("Неизветсный тип");
            }

            questionResult.Answers = answers;
            return questionResult;
        }

        private IAnswerOptions GetRandomElemFromArray(IEnumerable<IAnswerOptions> list)
        {
            if (!list.Any())
            {
                return null;
            }

            var index = _random.Next(list.Count());
            return list.ToList()[index];
        }
    }
}
