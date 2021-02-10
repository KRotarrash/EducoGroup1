using Moq;
using NUnit.Framework;
using Questionnaire.Answer;
using Questionnaire.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuestionFun = Questionnaire.Answer.QuestionnaireResult;

namespace QuestionnaireTest.Answer
{
    public class QuestionnaireResultTest
    {
        private QuestionFun question;

        [SetUp]
        public void Setup()
        {
            question = new QuestionFun();
        }

        [Test]
        [TestCase(1, 1, true)]
        [TestCase(2, 1, false)]
        public void IsFullResult_Test(int questionCount, int answerCount, bool isFullResult)
        {
            var mockQuestionnaire = new Mock<IQuestionnaireMain>();
            var listQuestionResults = new List<IQuestion>();
            for (int i = 0; i < questionCount; i++)
            {
                var mock = new Mock<IQuestion>();
                listQuestionResults.Add(mock.Object);
            }
            mockQuestionnaire.Setup(x => x.Questions).Returns(listQuestionResults);
            this.question.Questionnaire = mockQuestionnaire.Object;

            var listAnswerCount = new List<IQuestionResult>();
            for (int i = 0; i < answerCount; i++)
            {
                var mock = new Mock<IQuestionResult>();
                listAnswerCount.Add(mock.Object);
            }
            this.question.QuestionResults = listAnswerCount;

            var answer = this.question.IsFullResult();

            Assert.AreEqual(isFullResult, answer);
        }
    }
}
