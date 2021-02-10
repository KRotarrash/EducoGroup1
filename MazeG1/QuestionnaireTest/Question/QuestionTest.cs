using Moq;
using NUnit.Framework;
using Questionnaire.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuestionFun = Questionnaire.Question.Question;

namespace QuestionnaireTest.Question
{
    public class QuestionTest
    {
        private QuestionFun question;

        [SetUp]
        public void Setup()
        {
            question = new QuestionFun();
        }

        [Test]
        [TestCase("", false)]
        [TestCase("Fun fun", true)]
        public void IsValid_TextEmpty(string text, bool isValid)
        {
            question.Text = text;
            question.QuestionType = QuestionType.MultipleAnswer;
            var mock = new Mock<IAnswerOptions>();

            question.AnswerOptions = new List<IAnswerOptions>() { mock .Object };

            var answer = question.IsValid();

            Assert.AreEqual(isValid, answer);
        }

        [Test]
        public void IsValid_QuestionOptions_Empty()
        {
            question.Text = "Test";
            
            question.AnswerOptions = new List<IAnswerOptions>();

            var answer = question.IsValid();

            Assert.AreEqual(false, answer);
        }

        [Test]
        [TestCase(QuestionType.SingleAnswer, 1, false)]
        [TestCase(QuestionType.SingleAnswer, 2, true)]
        [TestCase(QuestionType.MultipleAnswer, 1, true)]
        [TestCase(QuestionType.MultipleAnswer, 2, true)]
        public void IsValid_QuestionType(QuestionType questionType, int count, bool isValid)
        {
            question.Text = "Test";
            question.QuestionType = questionType;
            var list = new List<IAnswerOptions>();
            for (int i = 0; i < count; i++)
            {
                var mock = new Mock<IAnswerOptions>();
                list.Add(mock.Object);
            }
            question.AnswerOptions = list;

            var answer = question.IsValid();

            Assert.AreEqual(isValid, answer);
        }
    }
}
