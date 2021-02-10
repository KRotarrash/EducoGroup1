using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication.DbStuff.Repository.Hotels;
using WebApplication.DbStuff.Repository.IRepository.IHotels;
using WebApplication.Service;

namespace WebApplication.Controllers.CustomAttribute
{
    public class HotelOwnerOrHelperAttribute : TypeFilterAttribute
    {
        public HotelOwnerOrHelperAttribute() : base(typeof(HotelOwnerOrHelperFilter)) { }
    }

    public class HotelOwnerOrHelperFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var hotelIdStr = context.HttpContext.Request.Query["hotelId"].ToString();
            var hotelId = long.Parse(hotelIdStr);

            var userService = context.HttpContext.RequestServices.GetService(typeof(IUserService)) as UserService;
            var hotelRepository = context.HttpContext.RequestServices.GetService(typeof(IHotelRepository)) as HotelRepository;

            var user = userService.GetCurrentUser();
            var hotel = hotelRepository.Get(hotelId);

            if (hotel.Owner?.Id != user.Id && hotel.Id != user.HotelUserIsHelper?.Id)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
