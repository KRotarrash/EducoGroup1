using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Institutions;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Model.Job;
using WebApplication.DbStuff.Repository.IRepository.IRestaurant;

namespace WebApplication.DbStuff.Repository.OrderRestaurant
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(WebContext webContext) : base(webContext) { }

        public IQueryable<Order> GetOrdersInBasketByCustomer(SpecialUser customer)
        {
            return _dbSet.Where(x => x.Сustomer == customer 
                                    && x.State == OrderState.InBasket);
        }

        public Order GetInBasketByCustomerAndByRetaurantId(SpecialUser customer, long retaurantId)
        {
            return _dbSet.SingleOrDefault(x => 
                                       x.Сustomer == customer
                                    && x.Restaurant.Id == retaurantId
                                    && x.State == OrderState.InBasket);
        }

        public IQueryable<Order> GetByOrderState(OrderState orderState)
        {
            return _dbSet.Where(x => x.State == orderState);
        }
    }
}
