using System;
using System.Collections.Generic;
using System.Text;

namespace DbFile.Model
{
    public class DbCell : DbBaseModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public CellType CellType { get; set; }
    }

    public enum CellType
    {
        Ground = 1,
        Wall = 2,
        Coin = 3,
        Well = 4,
        Hero = 5 // создал временно
    }
}
