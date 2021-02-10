using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class MazeViewModel
    {
        public string Name { get; set; }
        public int CoinCount { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
        public List<CellViewModel> Cells { get; set; }
    }
}
