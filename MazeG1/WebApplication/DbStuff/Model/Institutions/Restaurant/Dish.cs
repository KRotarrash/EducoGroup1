using System.Collections.Generic;
using WebApplication.DbStuff.Model;

namespace WebApplication.DbStuff.Institutions
{
    public class Dish : BaseModel
    {
        public virtual string Name { get; set; }
        public virtual float Price { get; set; }
        public virtual int Grams { get; set; }
        public virtual string Description { get; set; }
        public virtual DishType DishType { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual List<OrderDish> Orders { get; set; }
    }
}