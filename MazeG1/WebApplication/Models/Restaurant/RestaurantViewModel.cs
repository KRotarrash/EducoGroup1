using System;
using System.Collections.Generic;
using WebApplication.DbStuff.Model.Job;
using WebApplication.DbStuff.Institutions;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.Restaurant
{
    public class RestaurantViewModel
    {
        public long Id { get; set; }
        public long OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int SalaryDate { get; set; }
        public long JobId { get; set; }
        public OrganizationType OrganizationType { get; set; }
        public DateTime StartWork { get; set; }
        public DateTime EndWork { get; set; }
        public UserViewModel User { get; set; }
        public List<UserViewModel> Users { get; set; }
        public List<RestaurantViewModel> Restaurants { get; set; }
        public List<DishViewModel> Dishes { get; set; }
    }
}
