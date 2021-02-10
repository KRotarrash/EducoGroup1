namespace MazeCore.CellStuff
{
    public interface ICell
    {
        char Symbol { get; }
        int X { get; set; }
        int Y { get; set; }
        bool TryToStep();
    }
}