using MazeCore.CellStuff;
using System.Collections;
using System.Collections.Generic;

namespace MazeCore
{
    public interface IMaze
    {
        List<ICell> Cells { get; set; }
        List<ICell> CellsWithHero { get; }
        int Height { get; set; }
        IHero Hero { get; }
        int Width { get; set; }

        bool IsValid();
        void ReplaceCell(ICell cell);
        void ReplaceCell(List<ICell> cells, ICell cell);
        void TryToStep(Direction dir);
    }
}