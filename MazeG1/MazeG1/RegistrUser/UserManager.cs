using MazeCore;
using System;

namespace MazeG1
{
    class UserManager
    {
        /// <summary>
        /// Опрашивает пользователя и возвращает объект Human
        /// </summary>
        /// <returns></returns>
        public Human BuildHuman()
        {
            Console.WriteLine("Как тебя зовут?");
            string name = Console.ReadLine();
            Console.WriteLine($"Привет, {name}. Рад тебя видеть");

            int age = ConsoleHelper.ReadInt($"Сколько тебе лет, {name}?");

            if (age < 18)
            {
                Console.WriteLine($"Слишком рано");
                return null;
            }

            return new Human(name, age);
        }

        public Human GetDefaultHuman()
        {
            return new Human("Smile", 30);
        }

        public void Play(MazeCore.Maze maze)
        {
            var drawer = new Drawer();
            while (true)
            {
                drawer.DrawMaze(maze);
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        Console.WriteLine();
                        Console.WriteLine("good bye");
                        return;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        maze.TryToStep(Direction.Down);
                        break;
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        maze.TryToStep(Direction.Up);
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        maze.TryToStep(Direction.Left);
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        maze.TryToStep(Direction.Right);
                        break;
                }
            }
        }

    }
}
