using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;

namespace WebApplication.Models
{
    public class CalcViewModel
    {
        public Oper Operation { get; set; }
        public float Number1 { get; set; }
        public float Number2 { get; set; }
        public float Answer { get; set; }
        public List<CalcHistoryViewModel> CalcHistory { get; set; }
    }
}
