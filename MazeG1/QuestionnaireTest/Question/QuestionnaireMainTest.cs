using Moq;
using NUnit.Framework;
using Questionnaire.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestionnaireTest.Question
{
    public class QuestionnaireMainTest
    {
        private QuestionnaireMain questionnaireMain;

        [SetUp]
        public void Setup()
        {
            questionnaireMain = new QuestionnaireMain();
        }

        [Test]
        public void Questions_MustHaveAtleastOneQuestion()
        {
            //Подготовка
            questionnaireMain.Questions = new List<IQuestion>();

            //Действие
            var answer = questionnaireMain.IsValid();

            //Проверки
            Assert.AreEqual(false, answer);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void Questions_CallQuestionIsValid(bool isValidQuestion)
        {
            //Подготовка
            var questionMock = new Mock<IQuestion>();
            questionMock.Setup(x => x.IsValid()).Returns(isValidQuestion);
            questionnaireMain.Questions = new List<IQuestion>() { questionMock.Object };

            //Действие
            var answer = questionnaireMain.IsValid();

            //Проверки
            Assert.AreEqual(isValidQuestion, answer);
            questionMock.Verify(x => x.IsValid(), Times.Once);
        }
    }
}
