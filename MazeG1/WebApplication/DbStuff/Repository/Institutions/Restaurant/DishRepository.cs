using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Institutions;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Repository.IRepository.IJob;
using WebApplication.DbStuff.Repository.Job;

namespace WebApplication.DbStuff.Repository
{
    public class DishRepository : BaseRepository<Dish>, IDishRepository
    {
        public DishRepository(WebContext webContext) : base(webContext) { }

        public IEnumerable<Dish> GetByNameAndRestaurantId(string text, long restaurantId)
        {
            return _dbSet.Where(x => x.Name.Contains(text) && x.Restaurant.Id == restaurantId);
        }

        public IQueryable<Dish> GetByRestaurantId(long restaurantId)
        {
            return _dbSet.Where(x => x.Restaurant.Id == restaurantId);
        }

        public Dish GetDishByOrderDish(OrderDish orderDish)
        {
            return _dbSet.SingleOrDefault(x => x.Id == orderDish.Dish.Id);
        }

    }
}
