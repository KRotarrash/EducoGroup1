using DocumentFormat.OpenXml.Drawing.Diagrams;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;
using WebApplication.Models.CustomAttribute;

namespace WebApplication.Models
{
    public class MazeCoreMethodViewModel
    {
        public string MethodName { get; set; }

        public string InputParams { get; set; }

        public Type ReturnType { get; set; }

        public bool IsPublic { get; set; }

        public bool IsStatic { get; set; }

        public TypeElement TypeElement { get; set; }
    }
}
