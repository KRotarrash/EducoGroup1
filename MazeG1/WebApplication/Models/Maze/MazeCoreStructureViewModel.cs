using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;

namespace WebApplication.Models
{
    public class MazeCoreStructureViewModel
    {
        public string ProjectName { get; set; }

        public List<MazeCoreClassViewModel> Classes { get; set; }
    }
}
