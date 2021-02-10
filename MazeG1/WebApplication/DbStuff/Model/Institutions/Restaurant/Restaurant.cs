using System.Collections.Generic;
using WebApplication.DbStuff.Model.Job;

namespace WebApplication.DbStuff.Institutions
{
    public class Restaurant : Organization
    {
        public virtual List<Dish> Dishes { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
