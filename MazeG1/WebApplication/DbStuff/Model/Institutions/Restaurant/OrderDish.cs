using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;

namespace WebApplication.DbStuff.Institutions
{
    public class OrderDish : BaseModel
    {
        public virtual Order Order { get; set; }
        public virtual Dish Dish { get; set; }
    }
}
