using AutoMapper;
using DbFile;
using DbFile.Model;
using DbFile.Model.QuestionnaireStuff;
using MazeCore;
using MazeCore.CellStuff;
using MazeG1.Maze;
using MazeG1.Question;
using MazeG1.RegistrUser;
using Questionnaire;
using Questionnaire.Answer;
using Questionnaire.Question;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace MazeG1
{
    class Program
    {
        static void Main(string[] args)
        {
            //DefaultCase();
            ReflectionCase();
        }

        private static void ReflectionCase()
        {
            Console.WriteLine("Test");

            var maze = new MazeCore.Maze(10, 10);

            var type = maze.GetType();
            var type2 = typeof(MazeCore.Maze);

            var assembly = Assembly.GetExecutingAssembly();
            assembly.GetTypes();

            //var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            //var filed = fields.First(x => x.Name == "_width");
            //filed.SetValue(maze, -50);

            var properties = type.GetProperties();
            var methods = type.GetMethods();

            var crts = type.GetConstructors();

            foreach (var method in methods)
            {
                Console.WriteLine($"Метод называется {method.Name}. ");
                var attrDesc = method
                    .CustomAttributes
                    .FirstOrDefault(x => x.AttributeType == typeof(DescriptionAttribute));
                if (attrDesc != null)
                {
                    Console.WriteLine($"\tНо у него так же есть и особое имя");
                }

                Console.WriteLine($"\tВходные параметры");
                var inputParams = method.GetParameters();
                foreach (var param in inputParams)
                {
                    Console.WriteLine($"\t\t{param.ParameterType.Name} {param.Name}");
                }
                Console.WriteLine($"\t Возвращаемый тип {method.ReturnType.Name}");
            }

        }

        private static void DefaultCase()
        {
            Console.WriteLine("---Доброго времени суток!");

            var lessons = new ChoiseTask();
            var numTask = lessons.NameTasks();

            switch (numTask)
            {
                case TaskType.UserTask:
                    var taskLogin = new UserReg();
                    taskLogin.Registrarion();
                    break;
                case TaskType.MazeTask:
                    var taskMaze = new MazeStart();
                    taskMaze.StartM();
                    break;
                case TaskType.QuestionaryTask:
                    var taskProfile = new QuestionaryStart();
                    taskProfile.StartQ();
                    break;
            }
        }
    }
}
