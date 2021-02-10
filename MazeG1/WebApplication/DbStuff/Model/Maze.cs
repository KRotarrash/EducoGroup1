using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DbStuff.Model
{
    public class Maze : BaseModel
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public virtual List<MazeUser> Gamers { get; set; }
    }
}
