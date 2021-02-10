using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Institutions;
using WebApplication.DbStuff.Repository.IRepository.IRestaurant;

namespace WebApplication.DbStuff.Repository.OrderRestaurant
{
    public class OrderDishRepository : BaseRepository<OrderDish>, IOrderDishRepository
    {
        public OrderDishRepository(WebContext webContext) : base(webContext) { }
    }
}
