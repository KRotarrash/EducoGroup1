using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models.KeyClasses;

namespace WebApplication.Models
{
    public class KeyClassViewModel
    {
        public string ClassName { get; set; }
        public bool IsEnum { get; set; }
        public List<EnamViewModel> EnamField { get; set; }
        public List<MemberViewModel> Members { get; set; }
        public List<KeyClassViewModel> KeyClasses { get; set; } 

    }
}
