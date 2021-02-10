using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;
using WebApplication.Localization;
using WebApplication.Service;

namespace WebApplication.Controllers.CustomAttribute
{
    public class CustomLocalizationAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            var userService = context.HttpContext
                .RequestServices.GetService(typeof(IUserService)) as IUserService;
            var user = userService.GetCurrentUser();
            CultureInfo culture;
            switch (user?.SupportLang)
            {
                case SupportLang.Ru:
                    culture = CultureInfo.GetCultureInfo("ru-RU");
                    break;
                case SupportLang.En:
                    culture = CultureInfo.GetCultureInfo("en-US");
                    break;
                default:
                    culture = null;
                    break;
            }
            if (culture != null)
            {
                CultureInfo.DefaultThreadCurrentCulture = culture;
                Home.Culture = CultureInfo.DefaultThreadCurrentCulture;
            }

            base.OnResultExecuted(context);
        }
    }
}
