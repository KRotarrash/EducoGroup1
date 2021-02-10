using MazeCore.CellStuff;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MazeCore
{
    public class Maze : IMaze
    {
        private int _index = 0;
        private int _width = 3;
        private int _height = 3;

        public int Width
        {
            get => _width;
            set
            {
                if (value >= 3)
                {
                    _width = value;
                }
            }
        }
        public int Height
        {
            get => _height;
            set
            {
                if (value >= 3)
                {
                    _height = value;
                }
            }
        }

        public IHero Hero => CellStuff.Hero.GetHero;

        /// <summary>
        /// Только ландшафт без героя
        /// </summary>
        public List<ICell> Cells { get; set; }
        public List<ICell> CellsWithHero
        {
            get
            {
                var copyCells = Cells.Select(x => x).ToList();
                ReplaceCell(copyCells, Hero);
                return copyCells;
            }
        }

        /// <summary>
        /// Заполняем поля Лабиринта
        /// </summary>
        /// <param name="width">Ширина лабиринта</param>
        /// <param name="height">Высота лабиринта</param>
        public Maze(int width, int height)
        {
            Width = width;
            Height = height;
            Cells = new List<ICell>();
        }

        /// <summary>
        /// Новая ячейка будет помещена в список Cells
        /// </summary>
        /// <param name="cell"></param>
        public void ReplaceCell(ICell cell)
        {
            ReplaceCell(Cells, cell);
        }

        public void ReplaceCell(List<ICell> cells, ICell cell)
        {
            var oldCell = cells
                .Single(currentCell => currentCell.X == cell.X && currentCell.Y == cell.Y);
            cells.Remove(oldCell);
            cells.Add(cell);
        }

        public void TryToStep(Direction dir)
        {
            ICell destanationCell;
            switch (dir)
            {
                case Direction.Up:
                    destanationCell = Cells
                        .SingleOrDefault(x => x.X == Hero.X && x.Y == Hero.Y - 1);
                    break;
                case Direction.Down:
                    destanationCell = Cells
                        .SingleOrDefault(x => x.X == Hero.X && x.Y == Hero.Y + 1);
                    break;
                case Direction.Left:
                    destanationCell = Cells
                        .SingleOrDefault(x => x.X == Hero.X - 1 && x.Y == Hero.Y);
                    break;
                case Direction.Right:
                    destanationCell = Cells
                        .SingleOrDefault(x => x.X == Hero.X + 1 && x.Y == Hero.Y);
                    break;
                default:
                    destanationCell = null;
                    break;
            }

            if (destanationCell?.TryToStep() ?? false)
            {
                Hero.X = destanationCell.X;
                Hero.Y = destanationCell.Y;
            }
        }

        public bool IsValid()
        {
            bool res = Width >= 2 && Width <= 99 && Height >= 2 && Height <= 99;
            return res;
        }
    }
}
