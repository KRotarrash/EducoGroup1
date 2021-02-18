using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models.Restaurant;
using WebApplication.Presentation;

namespace WebApplication.Controllers
{
    [Authorize]
    public class RestaurantController : Controller
    {
        public RestaurantPresentation _restaurantPresentation;

        public RestaurantController(RestaurantPresentation restaurantPresentation)
        {
            _restaurantPresentation = restaurantPresentation;
        }

        public IActionResult Index()
        {
            var model = _restaurantPresentation.Index();

            return View(model);
        }

        public IActionResult SelectRestaurant(long id)
        {
            var model = _restaurantPresentation.SelectRestaurant(id);

            return View(model);
        }

        [HttpGet]
        public IActionResult AddDish(long id)
        {
            var model = _restaurantPresentation.AddDish(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult AddDish(DishViewModel model)
        {
            _restaurantPresentation.AddDish(model);

            return Redirect($"AddDish/{model.RestaurantId}");
        }

        [HttpGet]
        public IActionResult UpdateDish(long dishId)
        {
            return View(_restaurantPresentation.UpdateDish(dishId));
        }

        [HttpPost]
        public IActionResult UpdateDish(DishViewModel model)
        {
            _restaurantPresentation.UpdateDish(model);

            return Redirect($"SelectMenu?restaurantId={model.RestaurantId}");
        }

        public IActionResult RemoveDish(long dishId, long restaurantId)
        {
            _restaurantPresentation.RemoveDish(dishId);

            return Redirect($"SelectMenu?restaurantId={restaurantId}");
        }

        [HttpGet]
        public IActionResult SelectMenu(long restaurantId)
        {
            var model = _restaurantPresentation.SelectMenu(restaurantId);

            return View(model);
        }

        [HttpGet]
        public IActionResult MenuDishEdit()
        {
            return View();
        }

        [HttpGet]
        public IActionResult OrderSelect()
        {
            var model = _restaurantPresentation.GetNewOrderViewModels();
            return View(model);
        }

        [HttpGet]
        public IActionResult OrderBin()
        {
            var model = _restaurantPresentation.OrderBin();
            return View(model);
        }

        [HttpGet]
        public IActionResult ConfirmOrder(long orderId)
        {
            _restaurantPresentation.ConfirmOrder(orderId);
            return RedirectToAction("OrderSelect", "Restaurant");
        }
        [HttpGet]
        public IActionResult CancelOrder(long orderId, string redirectPage)
        {
            _restaurantPresentation.CancleOrder(orderId);
            return RedirectToAction(redirectPage, "Restaurant");
        }

        public IActionResult CancelDishInOrder(long orderId ,long dishId, string redirectPage)
        {
            _restaurantPresentation.CancelDishInOrder (orderId, dishId);
            return RedirectToAction(redirectPage, "Restaurant");
        }

        public IActionResult AddToBasket(long restId, long dishId)
        {
            _restaurantPresentation.AddDishToBasket(restId, dishId);
            return RedirectToAction("SelectMenu", "Restaurant", new { restaurantId = restId });
        }

        public IActionResult AddOrder(long orderId)
        {
            _restaurantPresentation.AddOrder(orderId);
            return RedirectToAction("Index", "Restaurant");
        }

        public IActionResult GetDishCountInBasket()
        {
            var data = _restaurantPresentation.GetDishCountInBasket();            
            return Json(data);
        }
    
        public IActionResult GetDishByName(string text, long restaurantId)
        {
            var dishOptions = _restaurantPresentation.GetDishByName(text, restaurantId);
            return Json(dishOptions);
        }
    }
}