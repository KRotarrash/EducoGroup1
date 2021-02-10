using MazeCore.CellStuff;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MazeCore
{
    public class MazeGenerator
    {
        private Maze _maze;
        private Random _random = new Random();

        public Maze Generate(int width, int height, double chanceOfCoin = 0.1, int maxCountOfWell = 3)
        {
            if (width < 3)
            {
                width = 3;
            }
            if (height < 3)
            {
                height = 3;
            }

            _maze = new Maze(width, height);

            GenerateWall();

            GenerateGround();

            GenerateWell(maxCountOfWell);

            GenerateCoins(chanceOfCoin);

            return _maze;
        }

        private void GenerateWall()
        {
            for (int y = 0; y < _maze.Height; y++)
            {
                for (int x = 0; x < _maze.Width; x++)
                {
                    var wall = new Wall(x, y, _maze);
                    _maze.Cells.Add(wall);
                }
            }
        }

        private void GenerateGround()
        {
            var keyCell = _maze.Cells.First();
            var greenWall = new List<ICell>();
            do
            {
                greenWall.Remove(keyCell);

                var ground = new Ground(keyCell.X, keyCell.Y, _maze);
                _maze.ReplaceCell(ground);

                var nearWall = GetNearCells<Wall>(keyCell);

                greenWall.AddRange(nearWall);
                greenWall = greenWall
                    .Where(wall => GetNearCells<Ground>(wall).Count() <= 1)
                    .ToList();

                keyCell = GetRandom(greenWall);
            } while (greenWall.Any());
        }

        private void GenerateCoins(double chanceOfCoin)
        {
            foreach (var ground in _maze.Cells.OfType<Ground>().ToList())
            {
                if (_random.NextDouble() <= chanceOfCoin)
                {
                    var coin = new Coin(ground.X, ground.Y, _maze);
                    _maze.ReplaceCell(coin);
                }
            }
        }

        private List<T> GetNearCells<T>(ICell keyCell) where T : BaseCell
        {
            return _maze.Cells.Where(
                cell => cell.X == keyCell.X && cell.Y == keyCell.Y - 1
                || cell.X == keyCell.X && cell.Y == keyCell.Y + 1
                || cell.X == keyCell.X + 1 && cell.Y == keyCell.Y
                || cell.X == keyCell.X - 1 && cell.Y == keyCell.Y)
                .OfType<T>()
                .ToList();
        }

        private ICell GetRandom(IEnumerable<ICell> cells)
        {
            if (!cells.Any())
            {
                return null;
            }

            var index = _random.Next(cells.Count());
            return cells.ToList()[index];
        }

        private void GenerateWell(int maxCountOfWell)
        {
            var groundDeadEnd = _maze.Cells.OfType<Ground>()
                .Where(x => GetNearCells<Wall>(x).Count() == 3);

            for (int i = 0; i < Math.Min(maxCountOfWell, groundDeadEnd.Count()); i++)
            {
                var cell = GetRandom(groundDeadEnd);
                var xWell = cell.X;
                var yWell = cell.Y;
                var well = new Well(xWell, yWell, _maze);
                _maze.ReplaceCell(well);
            }
        }
    }
}
