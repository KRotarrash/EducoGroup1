using DbFile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class CellViewModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public CellType CellType { get; set; }
    }
}
