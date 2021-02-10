using AutoMapper;
using DbFile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DbFile.Model.QuestionsAnswer;

namespace MazeG1
{
    class UserList
    {
        public static List<User> air = new List<User>();

        private FileUser rep;
        private Mapper mapper;
        public UserList()
        {
            var mapperBuilder = new MapperBuilder();
            mapper = mapperBuilder.GetMapper();
            rep = new FileUser();
        }


        /// <summary>
        /// Проверка работы с файлами ( save and get )
        /// </summary>
        /// <returns></returns>
        public User GetUser()
        {
            Console.WriteLine("1Вывод данных \n 2 Внести новые");
            int num = Convert.ToInt32(Console.ReadLine());

            switch (num)
            {
                case 1:
                    Console.WriteLine("ID пользователя");
                    int id = Convert.ToInt32(Console.ReadLine());
                    // Console.WriteLine("Файла ");
                    // string namefile = Console.ReadLine();
                    return Login(id);

                case 2:
                    return Profile();
                default:
                    return null;

            }



            // return Profile();
        }


        public User Login(int id)
        {
            //Console.WriteLine("ID user");
            //id = Convert.ToInt32(Console.ReadLine());

            //.WriteLine("Ваше имя:");
            //var name = Console.ReadLine();


            var dbUsers = rep.Get();
          
           var dbUser = dbUsers.FirstOrDefault(x => x.IDUser == id);
                
            var user = mapper.Map<User>(dbUser);

            Console.WriteLine($"Пользователь: {user.IDUser}  Имя файла ответов: {user.NameFileAnswers }");
          
            return user;

        }

        /// <summary>
        /// Ручное добавление Пользователя и Файла для проверки данных
        /// </summary>
        /// <returns></returns>
        public User Profile()
        {
            var user = new User();

            Console.WriteLine("Файла ответов (.txt или .json):");
            user.NameFileAnswers = Console.ReadLine();

            Console.WriteLine("Ваш id:");
            user.IDUser = Convert.ToInt32(Console.ReadLine());


            ///save
            var dbUser = mapper.Map<DbUser>(user);
            rep.Save(dbUser);


            return user;
        }



        public User IdUseradd()
        {
            /* var user = new User();

             var dbUsers = rep.Get();

             var dbUser = dbUsers.LastOrDefault(x => x.IDUser == dbUsers.Count());
             user = mapper.Map<User>(dbUser);
             var newIdUser = user.IDUser + 1;



             return user;*/
            return null;
        }
    }
}
