using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;

namespace WebApplication.DbStuff.Institutions
{
    public class Order : BaseModel
    {
        public virtual Restaurant Restaurant { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual SpecialUser Сustomer { get; set; }
        public virtual List<OrderDish> Dishes { get; set; } 
        public virtual OrderState State { get; set; }
    }
}
