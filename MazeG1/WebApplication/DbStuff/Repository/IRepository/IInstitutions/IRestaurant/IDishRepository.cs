using System.Collections.Generic;
using System.Linq;
using WebApplication.DbStuff.Institutions;

namespace WebApplication.DbStuff.Repository
{
    public interface IDishRepository : IBaseRepository<Dish>
    {
        IEnumerable<Dish> GetByNameAndRestaurantId(string text, long restaurantId);
        IQueryable<Dish> GetByRestaurantId(long restaurantId);
    }
}