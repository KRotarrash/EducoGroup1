using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.KeyClasses
{
    public class MemberViewModel
    {
        public string MemberName { get; set; }
        public string InputParams { get; set; }
        public Type ReturnType { get; set; }
        public bool IsPublic { get; set; }
        public bool IsStatic { get; set; }
        public TypeElement TypeElement { get; set; }
    }
}
