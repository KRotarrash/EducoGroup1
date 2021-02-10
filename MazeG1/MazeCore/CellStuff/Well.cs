using System;
using System.Collections.Generic;
using System.Text;

namespace MazeCore.CellStuff
{
    public class Well : BaseCell
    {
        public Well(int x, int y, IMaze maze) : base(x, y, 'U', maze)
        {
        }

        public override bool TryToStep()
        {
            Maze.Hero.Money--;
            //Hero.GetHero.Money--;
            return true;
        }
    }
}
