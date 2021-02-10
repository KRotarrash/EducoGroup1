using System;
using System.Collections.Generic;
using System.Text;

namespace MazeG1
{
    class ChoiseTask
    {
        public TaskType NameTasks() //(object lessonName, int lessonN)
        {
            string task = "   Выберите, какое задание вы хотите выполнить:" +
                                  "\r\n 1 - Зарегистрироваться" +
                                  "\r\n 2 - Запустить лабиринт" +
                                  "\r\n 3 - Запустить бота для анкеты" +
                                  "\r\n choose your destiny... ";
            
            int taskN = ConsoleHelper.ReadInt(task);
            while (taskN < 1 || taskN > 3)
            {
                Console.WriteLine("Нужно ввести номер задания!\n");
                taskN = ConsoleHelper.ReadInt(task);
            }

            return (TaskType)taskN;
        }
    }

    public enum TaskType
    {
        UserTask = 1,
        MazeTask = 2,
        QuestionaryTask = 3
    }
}
