using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;

namespace WebApplication.Models
{
    public class MazeCoreClassViewModel
    {
        public string ClassName { get; set; }

        public bool IsEnum { get; set; }

        public List<MazeCoreMethodViewModel> Methods { get; set; }
    }
}
