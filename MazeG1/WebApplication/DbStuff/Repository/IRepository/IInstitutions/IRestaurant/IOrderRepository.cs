using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Institutions;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Model.Job;

namespace WebApplication.DbStuff.Repository.IRepository.IRestaurant
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        IQueryable<Order> GetOrdersInBasketByCustomer(SpecialUser customer);
        Order GetInBasketByCustomerAndByRetaurantId(SpecialUser customer, long retaurantId);
        IQueryable<Order> GetByOrderState(OrderState orderState);
    }
}
