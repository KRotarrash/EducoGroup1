using Moq;
using NUnit.Framework;
using Questionnaire.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuestionFun = Questionnaire.Generator.SimpleQuestionare;

namespace QuestionnaireTest.Generator
{
    public class SimpleQuestionareTest
    {
        private QuestionFun questionnaire;

        [SetUp]
        public void Setup()
        {
            questionnaire = new QuestionFun();
        }

        [Test]
        public void Generate_CountQuestion()
        {
            var generateQuestionnaire = questionnaire.Generate();

            var questionCount = generateQuestionnaire.Questions.Count();

            Assert.AreEqual(5, questionCount);
        }

        [Test]
        [TestCase("Ваш пол:", QuestionType.SingleAnswer, 2)]
        [TestCase("Образование:", QuestionType.SingleAnswer, 3)]
        [TestCase("Виды спорта, которыми Вы занимаетесь:", QuestionType.MultipleAnswer, 6)]
        [TestCase("Музыка, которую Вы слушаете:", QuestionType.MultipleAnswer, 6)]
        [TestCase("Понравился ли Вам опросник?", QuestionType.SingleAnswer, 3)]
        public void Generate_QuestionTest(string text, QuestionType questionType, int countAnswer)
        {
            var generateQuestionnaire = questionnaire.Generate();

            var question = generateQuestionnaire.Questions.FirstOrDefault(x => x.Text == text);
            var questExist = question != null;
            var questType = question.QuestionType;
            var questAnswer = question.AnswerOptions.Count();

            // проверка на существование вопроса
            Assert.AreEqual(true, questExist);
            Assert.AreEqual(questionType, questType);
            Assert.AreEqual(countAnswer, questAnswer);
        }
    }
}
