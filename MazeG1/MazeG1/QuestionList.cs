using AutoMapper;
using DbFile;
using DbFile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeG1
{
    class QuestionList : QuestionnarieList
    {
        public static List<Question> questionlist = new List<Question>();

        private FileQuestions rep;
        private Mapper mapper;
        public QuestionList()
        {
            var mapperBuilder = new MapperBuilder();
            mapper = mapperBuilder.GetMapper();
            rep = new FileQuestions();
        }



        public Question GetQuestion()
        {
            Console.WriteLine("1Вывод данных \n 2 Внести новые");
            int num = Convert.ToInt32(Console.ReadLine());

            switch (num)
            {
                case 1:

                    return ListQuestion();

                case 2:
                    return AddQuestion();


                default:
                    return null;

            }


            // return Profile();
        }

        private Question ListQuestion()
        {
            var user = new Question();

            questionlist.Clear();
            var dbUsers = rep.Get();


            Console.WriteLine("Номер опросника:");
            var id_listq = Convert.ToInt32(Console.ReadLine());
            var id1 = IdQuestionnarie(id_listq);
            var id2 = IdQuestion(id_listq);


            if (id1 == null)
            {
                Console.WriteLine("Нет опросника с таким номером!");
                return null;
            }
            if (id2 == null)
            { Console.WriteLine("Нет вопросов"); }


            else
            {
                //Console.WriteLine();
                for (int i = 0; i <= dbUsers.Count(); i++)//временно
                {

                    var dbUser = dbUsers.FirstOrDefault(x => x.ID_count == i);
                    user = mapper.Map<Question>(dbUser);
                    questionlist.Add(user);

                }

                if (questionlist.Count == 0) { Console.WriteLine("\n Анкеты нет!!!\n"); }
                else
                {
                    foreach (Question ar in questionlist)
                    {
                        if (ar != null && ar.IdQuestionnaire == id_listq)
                        {
                            Console.WriteLine($"Вопрос: {ar.ID} {ar.TextQuestion}");
                            Console.WriteLine($"Варианты ответов: ");
                            // if (ar.ID == user.ID)
                            {
                                Console.WriteLine($"1:  {ar.TextAnswer1}");//{ar.IdAnswerQuestion1}
                                Console.WriteLine($"2:  {ar.TextAnswer2}");
                                Console.WriteLine($"3:  {ar.TextAnswer3}");
                            }
                            //Console.WriteLine($"Введите число: ");
                            // int num=Convert.ToInt32( Console.ReadLine());

                            //IdAnswers(num);
                        }
                        else
                        { }//Console.WriteLine(""); }

                    }
                }
            }
            //}



            //}
            return user;

        }


        public Question IdQuestion(int name)
        {
            var user = new Question();


            var dbUsers = rep.Get();


            user = mapper.Map<Question>(dbUsers.FirstOrDefault(x => x.IdQuestionnaire == name));
            if (user == null)
            { Console.WriteLine("null"); }



            //else {  }


            //  Console.WriteLine(user.IdQuestionnaire );


            return user;
        }

        public Question IdAnswers(int ID)
        {
            var id_an = new Question();


            var dbUsers = rep.Get();



            id_an = mapper.Map<Question>(dbUsers.FirstOrDefault(x => x.ID == ID));
            if (id_an == null)
            { Console.WriteLine("null"); }
            else
            {
                if (id_an.IdAnswerQuestion1 == ID)
                {
                    questionlist.Add(id_an);
                    Console.WriteLine(id_an.TextAnswer1);
                    return id_an;
                }
                if (id_an.IdAnswerQuestion2 == ID)
                {
                    questionlist.Add(id_an);
                    Console.WriteLine(id_an.TextAnswer2);
                    return id_an;
                }
                if (id_an.IdAnswerQuestion3 == ID)
                {
                    questionlist.Add(id_an);
                    Console.WriteLine(id_an.TextAnswer3);
                    return id_an;
                }
            }

            return id_an;
        }


        public Question AddQuestion()
        {
            var user = new Question();

            Console.WriteLine("Номер опросника:");
            user.IdQuestionnaire = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= 5; i++)
            {
                user.ID = i;
                Console.WriteLine($"Номер Вопроса:{user.ID}");
                //Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Вопрос:");
                user.TextQuestion = Console.ReadLine();

                user.IdAnswerQuestion1 = 1;
                Console.WriteLine("1 Вариант ответа: ");
                user.TextAnswer1 = Console.ReadLine();

                user.IdAnswerQuestion2 = 2;
                Console.WriteLine("2 Вариант ответа: ");
                user.TextAnswer2 = Console.ReadLine();

                user.IdAnswerQuestion3 = 3;
                Console.WriteLine("3 Вариант ответа: ");
                user.TextAnswer3 = Console.ReadLine();

                Console.WriteLine("Id_count:");
                user.ID_count = Convert.ToInt32(Console.ReadLine());
                var dbUser = mapper.Map<DbQuestions>(user);
                rep.Save(dbUser);
            }

            ///save


            return user;
        }


        public Question AddQuestionAnswer(int id_listq, int Id, int id_q)
        {
            var user = new Question();


            var dbUsers = rep.Get();
            // var test;

            // Console.WriteLine("Номер опросника:");
            // id_listq = Convert.ToInt32(Console.ReadLine());
            var id1 = IdQuestionnarie(id_listq);
            var id2 = IdQuestion(id_listq);
            questionlist.Clear();

            if (id1 == null)
            {
                Console.WriteLine("Нет опросника с таким номером!");
                return null;
            }
            if (id2 == null)
            { Console.WriteLine("Нет вопросов"); }


            else
            {
                for (int i = 1; i <= 5; i++)//временно
                {
                    user = mapper.Map<Question>(dbUsers.FirstOrDefault(x => x.ID == i));
                    questionlist.Add(user);

                }

                if (questionlist.Count == 0) { Console.WriteLine("\n Анкеты нет!!!\n"); }
                else
                {
                    foreach (Question ar in questionlist)
                    {
                        if (ar != null)
                        {
                            if (ar.ID == id_q)
                            {
                                Console.WriteLine($"Вопрос{id_q}:  {ar.TextQuestion}");

                                if (ar.IdAnswerQuestion1 == Id)
                                {
                                    questionlist.Add(ar);
                                    Console.WriteLine(ar.TextAnswer1);
                                    return ar;
                                }
                                if (ar.IdAnswerQuestion2 == Id)
                                {
                                    questionlist.Add(ar);
                                    Console.WriteLine(ar.TextAnswer2);
                                    return ar;
                                }
                                if (ar.IdAnswerQuestion3 == Id)
                                {
                                    questionlist.Add(ar);
                                    Console.WriteLine(ar.TextAnswer3);
                                    return ar;
                                }
                                //IdAnswers(Id);
                            }

                        }
                        else
                        { }// Console.WriteLine(""); }

                    }
                }
            }

            return user;

        }
    }
}
