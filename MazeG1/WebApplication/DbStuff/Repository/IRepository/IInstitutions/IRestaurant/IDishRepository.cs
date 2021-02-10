using System.Collections.Generic;
using WebApplication.DbStuff.Institutions;

namespace WebApplication.DbStuff.Repository
{
    public interface IDishRepository : IBaseRepository<Dish>
    {
        IEnumerable<Dish> GetByName(string text, long restaurantId);
    }
}