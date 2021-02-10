using MazeG1.Exp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeG1
{
    class ConsoleHelper
    {
        public static int ReadInt(string message)
        {
            Console.WriteLine(message);
            string str = Console.ReadLine();

            int number;
            if (!int.TryParse(str, out number))
            {
                Console.WriteLine("Ты ввёл не число");
                number = 0;
            }

            if (number < 0)
            {
                throw new NegativeException();
            }

            return number;
        }
    }
}
