﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Service;

namespace WebApplication.Controllers.CustomAttribute
{
    public class IsFirefighterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userService = context.HttpContext
                .RequestServices.GetService(typeof(IUserService)) as IUserService;

            if (!userService.IsFirefighter())
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
