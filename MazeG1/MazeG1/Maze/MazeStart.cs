using MazeCore;
using MazeG1.RegistrUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeG1.Maze
{
    public class MazeStart
    {
        private Human user;
       
        public string StartM()
        {
            //лабиринт
            int width = 0;
            int height = 0;
            try
            {
                //    width = ConsoleHelper.ReadInt($"Какая будет ширина, {user.FullName()}?"); //не видит сохраненного пользователя. доделать. возможно private Human user; не создается.
                //    height = ConsoleHelper.ReadInt($"Какая будет высота, {user.FullName()}?");
                width = ConsoleHelper.ReadInt("Какая будет ширина?"); 
                height = ConsoleHelper.ReadInt("Какая будет высота?");
            }
            catch (FormatException)
            {
                width = 10;
                Console.WriteLine($"Не угадал, ширина будет {width}");
            }
            catch (NullReferenceException)
            {
                user = new Human("Test");
                Console.WriteLine($"Нет пользователя");
            }
            catch (MazeG1.Exp.NegativeException someExp)
            {
                Console.WriteLine(someExp.StackTrace);
                Console.WriteLine(someExp.Message);
            }

            var generat = new MazeGenerator();
            var maze = generat.Generate(width, height);

            var manager = new UserManager();
            manager.Play(maze); 
            return null;
        }
    }
}
