using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication.DbStuff.Model
{
    public class CalcHistory : BaseModel
    {
        public float Number1 { get; set; }
        public float Number2 { get; set; }
        public float Answer { get; set; }
        public Oper Operation { get; set; }
    }
}
