using System;
using System.Collections.Generic;
using System.Text;

namespace MazeCore.CellStuff
{
    public class Coin : BaseCell
    {

        public Coin(int x, int y, IMaze maze) : base(x, y, 'c', maze)
        {
        }
  

        public override bool TryToStep()
        {
            var ground = new Ground(X, Y, Maze);
            Maze.ReplaceCell(ground);

            //Hero.GetHero.Money++;
            Maze.Hero.Money++;
            return true;
        }
    }
}
