using System.ComponentModel.DataAnnotations;
using WebApplication.DbStuff.Institutions;

namespace WebApplication.Models.Restaurant
{
    public class DishViewModel
    {
        public long Id { get; set; }
        public long RestaurantId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int Grams { get; set; }
        public string Description { get; set; }
        public DishType DishType { get; set; }
    }
}