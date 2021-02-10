using Questionnaire.Question;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Questionnaire.Generator
{
    public class SimpleQuestionare
    {
        public IQuestionnaireMain Generate()
        {
            var sq = new QuestionnaireMain();
            sq.Name = "Simple questionnaire";
            sq.Questions = new List<Questionnaire.Question.Question>()
                {new Questionnaire.Question.Question()
                    { Text = "Ваш пол:", QuestionType = QuestionType.SingleAnswer,
                      AnswerOptions = new List<IAnswerOptions>() {
                          new AnswerOptions() {Text = "Male"},
                          new AnswerOptions() {Text = "Female"}
                        }
                    },
                 new Questionnaire.Question.Question()
                    { Text = "Образование:", QuestionType = QuestionType.SingleAnswer,
                      AnswerOptions = new List<IAnswerOptions>() {
                          new AnswerOptions() {Text = "начальное"},
                          new AnswerOptions() {Text = "среднее"},
                          new AnswerOptions() {Text = "высшее"}
                        }
                    },
                 new Questionnaire.Question.Question()
                    { Text = "Виды спорта, которыми Вы занимаетесь:", QuestionType = QuestionType.MultipleAnswer,
                      AnswerOptions = new List<IAnswerOptions>() {
                          new AnswerOptions() {Text = "бег"},
                          new AnswerOptions() {Text = "плавание"},
                          new AnswerOptions() {Text = "велоспорт"},
                          new AnswerOptions() {Text = "туризм"},
                          new AnswerOptions() {Text = "легкая атлетика"},
                          new AnswerOptions() {Text = "восточные единоборства"}
                        }
                    },
                 new Questionnaire.Question.Question()
                    { Text = "Музыка, которую Вы слушаете:", QuestionType = QuestionType.MultipleAnswer,
                      AnswerOptions = new List<IAnswerOptions>() {
                          new AnswerOptions() {Text = "классическая"},
                          new AnswerOptions() {Text = "народная"},
                          new AnswerOptions() {Text = "рок"},
                          new AnswerOptions() {Text = "металл"},
                          new AnswerOptions() {Text = "джаз"},
                          new AnswerOptions() {Text = "блюз"}
                        }
                    },
                 new Questionnaire.Question.Question()
                    { Text = "Понравился ли Вам опросник?", QuestionType = QuestionType.SingleAnswer,
                      AnswerOptions = new List<IAnswerOptions>() {
                          new AnswerOptions() {Text = "да"},
                          new AnswerOptions() {Text = "нет"},
                          new AnswerOptions() {Text = "затрудняюсь ответить"}
                        }
                    }
                };
            return sq;
        }
    }
}
