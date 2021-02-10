using Moq;
using NUnit.Framework;
using Questionnaire.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestionnaireTest.Question
{
    public class AnswerOptionsTest
    {
        private AnswerOptions answerOptions;

        [SetUp]
        public void Setup()
        {
            answerOptions = new AnswerOptions();
        }

        [Test]
        public void AnswerOptions_IsValid()
        {
            //Подготовка

            //Действие
            var answer = answerOptions.IsValid();

            //Проверки
            Assert.AreEqual(true, answer);
        }
    }
}
