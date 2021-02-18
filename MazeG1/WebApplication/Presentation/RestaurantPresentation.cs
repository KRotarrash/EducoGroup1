using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Institutions;
using WebApplication.DbStuff.Model.Job;
using WebApplication.DbStuff.Repository;
using WebApplication.DbStuff.Repository.IRepository.IJob;
using WebApplication.DbStuff.Repository.IRepository.IRestaurant;
using WebApplication.Models;
using WebApplication.Models.Restaurant;
using WebApplication.Service;

namespace WebApplication.Presentation
{
    public class RestaurantPresentation
    {
        private IMapper _mapper;
        private IUserService _userService;
        private IDishRepository _dishRepository;
        private IOrderRepository _orderRepository;
        private IRestaurantRepository _restaurantRepository;
        private IOrderDishRepository _orderDishRepository;

        public RestaurantPresentation(
            IMapper mapper,
            IUserService userService,
            IDishRepository dishRepository,
            IOrderRepository orderRepository,
            IRestaurantRepository restaurantRepository,
            IOrderDishRepository orderDishRepository)
        {
            _mapper = mapper;
            _userService = userService;
            _dishRepository = dishRepository;
            _orderRepository = orderRepository;
            _restaurantRepository = restaurantRepository;
            _orderDishRepository = orderDishRepository;
        }

        public void RemoveDish(long dishId)
        {
            if (dishId > 0)
            {
                _dishRepository.Remove(dishId);
            }
        }

        public DishViewModel UpdateDish(long dishId)
        {
            return _mapper.Map<DishViewModel>(_dishRepository.Get(dishId));
        }

        public void UpdateDish(DishViewModel model)
        {
            if (model.Id > 0)
            {
                _dishRepository.Save(_mapper.Map<Dish>(model));
                return;
            }
        }

        public DishViewModel AddDish(long id)
        {
            return new DishViewModel()
            {
                RestaurantId = id
            };
        }

        public void AddDish(DishViewModel model)
        {
            var dish = _mapper.Map<Dish>(model);
            dish.Restaurant = _restaurantRepository.Get(model.RestaurantId);

            _dishRepository.Save(dish);
        }

        public RestaurantViewModel SelectRestaurant(long id)
        {
            return _mapper.Map<RestaurantViewModel>(_restaurantRepository.Get(id));
        }

        public RestaurantViewModel Index()
        {
            return new RestaurantViewModel()
            {
                Restaurants = _mapper.Map<List<RestaurantViewModel>>(_restaurantRepository.GetAll().ToList()),
            };
        }

        public RestaurantViewModel SelectMenu(long restaurantId)
        {
            var model = _mapper.Map<RestaurantViewModel>(_restaurantRepository.Get(restaurantId));

            model.Dishes = _mapper.Map<List<DishViewModel>>(
                _dishRepository
                    .GetByRestaurantId(restaurantId)
                    .ToList());

            return model;
        }

        public List<OrderViewModel> GetNewOrderViewModels()
        {
            var newOrders = _orderRepository
                .GetByOrderState(OrderState.New)
                .ToList();

            return _mapper.Map<List<OrderViewModel>>(newOrders);
        }

        public void ConfirmOrder(long orderId)
        {
            var order = _orderRepository.Get(orderId);
            order.State = OrderState.Confirmed;

            _orderRepository.Save(order);
        }

        public void CancleOrder(long orderId)
        {
            var order = _orderRepository.Get(orderId);
            order.State = OrderState.Сanceled;

            _orderRepository.Save(order);
        }

        public List<DishOptionViewModel> GetDishByName(string text, long restaurantId)
        {
            var dishes = _dishRepository
                .GetByNameAndRestaurantId(text, restaurantId);

            return _mapper.Map<List<DishOptionViewModel>>(dishes.ToList());
        }

        public void CancelDishInOrder(long orderid, long dishId)
        {
            var order = _orderRepository.Get(orderid);

            var orderDish = _orderDishRepository
                .GetByOrderIdAndDishId(orderid, dishId);

            _orderDishRepository.Remove(orderDish);

            if (order.Dishes.Count < 1)
            {
                _orderRepository.Remove(order);
            }
        }

        public void AddDishToBasket(long restaurantId, long dishId)
        {
            var dish = _dishRepository.Get(dishId);
            var customer = _userService.GetCurrentUser();

            var order = _orderRepository
                .GetInBasketByCustomerAndByRetaurantId(customer, restaurantId);

            var orderDish = new OrderDish()
            {
                Order = order,
                Dish = dish
            };

            if (order != null)
            {
                order.Dishes.Add(orderDish);
            }
            else
            {
                order = new Order()
                {
                    Restaurant = _restaurantRepository.Get(restaurantId),
                    Сustomer = customer,
                    Dishes = new List<OrderDish>() { orderDish },
                    Date = DateTime.Now,
                    State = OrderState.InBasket
                };
            }
            _orderRepository.Save(order);
        }

        public List<OrderViewModel> OrderBin()
        {
            var customer = _userService.GetCurrentUser();

            var orders = _orderRepository
                .GetOrdersInBasketByCustomer(customer)
                .ToList();

            var result = new List<OrderViewModel>();

            if (orders.Any())
            {
                result = _mapper.Map<List<OrderViewModel>>(orders);
            }

            return result;
        }

        public void AddOrder(long orderId)
        {
            var order = _orderRepository.Get(orderId);
            order.State = OrderState.New;
            _orderRepository.Save(order);
        }

        public int GetDishCountInBasket()
        {
            var customer = _userService.GetCurrentUser();

            return customer?
                .Orders
                .Where(x => x.State == OrderState.InBasket)
                .Sum(x => x.Dishes.Count())
                ?? 0;
        }
    }
}
