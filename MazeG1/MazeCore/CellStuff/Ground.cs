using System;
using System.Collections.Generic;
using System.Text;

namespace MazeCore.CellStuff
{
    public class Ground : BaseCell
    {
        public Ground(int x, int y, IMaze maze) : base(x, y, '.', maze)
        {
        }

        public override bool TryToStep()
        {
            return true;
        }
    }
}
