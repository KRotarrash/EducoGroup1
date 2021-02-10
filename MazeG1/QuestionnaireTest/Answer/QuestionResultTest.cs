using Moq;
using NUnit.Framework;
using Questionnaire.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuestionFun = Questionnaire.Answer.QuestionResult;

namespace QuestionnaireTest.Answer
{
    public class SimpleQuestionareTest
    {
        private QuestionFun question;

        [SetUp]
        public void Setup()
        {
            question = new QuestionFun();
        }

        [Test]
        [TestCase(QuestionType.SingleAnswer, 1, true)]
        [TestCase(QuestionType.SingleAnswer, 2, false)]
        public void IsValidAnswer_QuestionType_Single(QuestionType questionType, int count, bool isValid)
        {
            var mockQuestion = new Mock<IQuestion>();
            mockQuestion.Setup(x => x.QuestionType).Returns(questionType);
            mockQuestion.Setup(x => x.Text).Returns("Test");
            this.question.Question = mockQuestion.Object;

            var listAnswer = new List<IAnswerOptions>();
            for (int i = 0; i < count; i++)
            {
                var mock = new Mock<IAnswerOptions>(); 
                listAnswer.Add(mock.Object);
            }
            this.question.Answers = listAnswer;

            var answer = this.question.IsValidAnswer();

            Assert.AreEqual(isValid, answer);
        }

        [Test]
        [TestCase(QuestionType.MultipleAnswer, 1, 2, true)]
        [TestCase(QuestionType.MultipleAnswer, 2, 2, true)]
        [TestCase(QuestionType.MultipleAnswer, 3, 2, false)]
        public void IsValidAnswer_QuestionType_Multiple(QuestionType questionType, int count, int countAnswerOptions, bool isValid)
        {
            var mockQuestion = new Mock<IQuestion>();
            mockQuestion.Setup(x => x.QuestionType).Returns(questionType);
            mockQuestion.Setup(x => x.Text).Returns("Test");
            var listAnswerOptions = new List<IAnswerOptions>();
            for (int i = 0; i < countAnswerOptions; i++)
            {
                var mock = new Mock<IAnswerOptions>();
                listAnswerOptions.Add(mock.Object);
            }
            mockQuestion.Setup(x => x.AnswerOptions).Returns(listAnswerOptions);
            this.question.Question = mockQuestion.Object;

            var listAnswer = new List<IAnswerOptions>();
            for (int i = 0; i < count; i++)
            {
                var mock = new Mock<IAnswerOptions>();
                listAnswer.Add(mock.Object);
            }
            this.question.Answers = listAnswer;

            var answer = this.question.IsValidAnswer();

            Assert.AreEqual(isValid, answer);
        }
    }
}
