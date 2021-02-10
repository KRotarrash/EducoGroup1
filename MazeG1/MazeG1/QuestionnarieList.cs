using AutoMapper;
using DbFile;
using DbFile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeG1
{
    class QuestionnarieList : UserList
    {
        public static List<Questionnarie> listq = new List<Questionnarie>();

        private FileQuestionnaire rep;
        private Mapper mapper;
        public QuestionnarieList()
        {
            var mapperBuilder = new MapperBuilder();
            mapper = mapperBuilder.GetMapper();
            rep = new FileQuestionnaire();
        }


        /// <summary>
        /// Проверка работы с файлами
        /// </summary>
        /// <returns></returns>
        public Questionnarie GetQuestionnarie()
        {
            Console.WriteLine("1)Вывод данных на экран \n2 Внести новые");
            int num = Convert.ToInt32(Console.ReadLine());

            switch (num)
            {
                case 1:
                    return ListQuestionnarie();

                case 2:
                    return AddQuestionnarie();
                default:
                    return null;

            }

        }

        /// <summary>
        /// Просотр списка опросника
        /// </summary>
        /// <returns></returns>
        public Questionnarie ListQuestionnarie()
        {
            var user = new Questionnarie();

            listq.Clear();

            var dbUsers = rep.Get();


            for (int i = 0; i <= dbUsers.Count(); i++)//временно
            {
                user = mapper.Map<Questionnarie>(dbUsers.FirstOrDefault(x => x.Id == i));
                listq.Add(user);
            }
            if (listq.Count == 0) { Console.WriteLine("\n Анкеты нет!!!\n"); }
            else
            {
                Console.WriteLine("Тесты");
                foreach (Questionnarie qr in listq)
                {
                    
                    if (qr != null)
                    { Console.WriteLine($" {qr.ID} : {qr.NameQuestionnaire}"); }
                   /* else
                    { Console.WriteLine("-"); }*/
                }
            }
            return user;

        }


        /// <summary>
        /// Добавление нового опросника
        /// </summary>
        /// <returns></returns>
        public Questionnarie AddQuestionnarie()
        {
            var user = new Questionnarie();

            Console.WriteLine("Название нового опросника:");
            user.NameQuestionnaire = Console.ReadLine();

            Console.WriteLine("Номер нового опросника:");//сделать автоматически
            user.ID = Convert.ToInt32(Console.ReadLine());


            ///save
            var dbUser = mapper.Map<DbQuestionnaire>(user);
            rep.Save(dbUser);

            return user;
        }


        /// <summary>
        /// Получение ID опросника
        /// </summary>
        /// <param id="передаваемое значение ID для поиска"> </param>
        /// <returns></returns>
        public Questionnarie IdQuestionnarie(int id)
        {
            var user = new Questionnarie();


            var dbUsers = rep.Get();


            user = mapper.Map<Questionnarie>(dbUsers.FirstOrDefault(x => x.Id == id));

            if (user == null)
            { return null; }
            // else { Console.WriteLine(user.ID_test); }////
            return user;
        }
    }
}
