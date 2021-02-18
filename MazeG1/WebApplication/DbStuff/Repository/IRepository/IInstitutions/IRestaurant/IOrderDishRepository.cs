using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Institutions;

namespace WebApplication.DbStuff.Repository.IRepository.IRestaurant
{
    public interface IOrderDishRepository : IBaseRepository<OrderDish>
    {
        OrderDish GetByOrderIdAndDishId(long orderId, long dishId);
    }
}
