using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Restaurant
{
    public class OrderViewModel
    {
        public long Id { get; set; }
        public RestaurantViewModel Restaurant { get; set; }
        public UserViewModel Customer { get; set; }
        public List<DishViewModel> Dishes { get; set; }
        public float TotalCost { get; set; }
        public DateTime Date { get; set; }
    }
}
