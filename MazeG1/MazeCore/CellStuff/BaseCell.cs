namespace MazeCore.CellStuff
{
    public abstract class BaseCell : ICell
    {
        public int X { get; set; }
        public int Y { get; set; }

        public char Symbol { get; private set; }
        protected IMaze Maze { get; set; }

        public BaseCell(int x, int y, char symbol, IMaze maze)
        {
            X = x;
            Y = y;
            Symbol = symbol;
            Maze = maze;
        }

        public abstract bool TryToStep();
    }
}
