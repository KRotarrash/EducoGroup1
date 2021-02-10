using AutoMapper.Internal;
using DbFile.Model;
using MazeCore;
using MazeCore.CellStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebApplication.DbStuff;
using WebApplication.Models;
using WebApplication.Models.KeyClasses;

namespace WebApplication.Presentation
{
    public class HomePresentation
    {
        private MazeGenerator _generator;
        private CalcPresentation _calcPresentation;

        public HomePresentation(MazeGenerator generator, 
            CalcPresentation calcPresentation)
        {
            _generator = generator;
            _calcPresentation = calcPresentation;
        }

        /// <summary>
        /// Генерирует и возвращает заполненный лабиринт
        /// </summary>
        /// <param name="widthMaze"></param>
        /// <param name="heightMaze"></param>
        /// <returns></returns>
        public MazeViewModel GetMazeViewModel(int widthMaze, int heightMaze)
        {
            var model = new MazeViewModel() // Создаем лабиринт типа MazeViewModel
            {
                //CoinCount = 15,
                Width = widthMaze,
                Height = heightMaze,
                Cells = new List<CellViewModel>()
            };

            var mazeGenerator = new MazeGenerator(); // Создается MazeGenerator из MazeCore
            var maze = mazeGenerator.Generate(model.Width, model.Height); // Создается лабиринт
            model.Cells = ConvertICellToCellViewModel(maze.CellsWithHero); // В model.Cells записываем сконвертированный список ячеек maze.CellsWithHero         

            return model;
        }

        /// <summary>
        /// Принимает список ячеек типа ICell и возвращает список ячеек типа CellViewModel
        /// </summary>
        /// <param name="cells"></param>
        /// <returns></returns>
        private List<CellViewModel> ConvertICellToCellViewModel(List<ICell> cells)
        {
            return cells.Select(cell =>
                new CellViewModel()
                {
                    X = cell.X,
                    Y = cell.Y,
                    CellType = GetCellType(cell)
                }).ToList();
        }

        private CellType GetCellType(ICell cell)
        {
            switch (cell.GetType().Name)
            {
                case nameof(Wall):
                    {
                        return CellType.Wall;
                    }
                case nameof(Ground):
                    {
                        return CellType.Ground;
                    }
                case nameof(Coin):
                    {
                        return CellType.Coin;
                    }
                case nameof(Well):
                    {
                        return CellType.Well;
                    }
                case nameof(Hero):
                    {
                        return CellType.Hero;
                    }
                default:
                    throw new Exception();
            }
        }

        public MazeCoreStructureViewModel GetMazeCoreStructure()
        {
            var modelView = new MazeCoreStructureViewModel();
            var types = Assembly.GetAssembly(typeof(MazeCore.Maze)).GetTypes();
            modelView.Classes = new List<MazeCoreClassViewModel>();
            foreach (Type type in types)
            {
                var model = new MazeCoreClassViewModel();
                model.ClassName = type.Name;
                model.IsEnum = type.IsEnum;

                var bindingFlagsAll =
                    BindingFlags.Public | BindingFlags.NonPublic
                    | BindingFlags.Static | BindingFlags.Instance;
                var methods = type.IsEnum
                    ? type.GetMethods(BindingFlags.Instance)
                    : type.GetMethods(bindingFlagsAll);
                var constuctors = type.IsEnum
                    ? type.GetConstructors(BindingFlags.Instance)
                    : type.GetConstructors(bindingFlagsAll);
                var fields = type.GetFields(bindingFlagsAll);
                model.Methods = new List<MazeCoreMethodViewModel>();

                var allElements = new List<MemberInfo>();
                allElements.AddRange(fields);
                allElements.AddRange(constuctors);
                allElements.AddRange(methods);

                foreach (var elem in allElements)
                {
                    model.Methods.Add(GenerateMazeCoreMethodViewModel(elem));
                }
                modelView.Classes.Add(model);
            }
            return modelView;
        }

        private MazeCoreMethodViewModel GenerateMazeCoreMethodViewModel(MemberInfo memberInfo)
        {
            var modelMethod = new MazeCoreMethodViewModel();
            modelMethod.MethodName = memberInfo.Name;
            modelMethod.IsPublic = memberInfo.IsPublic();
            modelMethod.IsStatic = memberInfo.IsStatic();

            var methodBase = memberInfo as MethodBase;
            if (methodBase != null)
            {
                // список параметров для конструкторов и методов
                var inputParams = methodBase.GetParameters();
                var inputParamsStr = inputParams
                    .Select(x => $"{x.Name} ({x.ParameterType.Name})");
                var strMethod = string.Join(", ", inputParamsStr);
                modelMethod.InputParams = strMethod;

                var methodInfo = memberInfo as MethodInfo;
                if (methodInfo != null)
                {
                    // метод
                    modelMethod.ReturnType = methodInfo.ReturnType;
                    modelMethod.TypeElement = TypeElement.Method;
                }
                else
                {
                    // конструктор
                    modelMethod.TypeElement = TypeElement.Contrsuctor;
                }
            }
            
            var fieldInfo = memberInfo as FieldInfo;
            if (fieldInfo != null)
            {
                // свойство
                modelMethod.ReturnType = fieldInfo.FieldType;
                modelMethod.TypeElement = TypeElement.Attribute;
            }
            return modelMethod;
        }
    }
}
