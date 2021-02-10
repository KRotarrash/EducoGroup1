using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Castle.Core.Internal;
using DbFile;
using DbFile.Model;
using DocumentFormat.OpenXml.Bibliography;
using MazeCore;
using MazeCore.CellStuff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApplication.DbStuff;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Repository;
using WebApplication.Localization;
using WebApplication.Models;
using WebApplication.Presentation;
using WebApplication.Service;
using WebApplication.Controllers.CustomAttribute;

namespace WebApplication.Controllers
{
    [CustomLocalization]
    public class HomeController : Controller
    {
        public HomePresentation _homePresentation;
        private ISpecialUserRepository _specialUserRepository;
        private IUserService _userService;

        public HomeController(ISpecialUserRepository specialUserRepository,
            HomePresentation homePresentation, IUserService userService)
        {
            _specialUserRepository = specialUserRepository;
            _homePresentation = homePresentation;            
            _homePresentation = homePresentation;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ResourceJson()
        {
            var dictionary = new Dictionary<string, string>();
            //var cultureInfo = CultureInfo.GetCultureInfo("ru-RU");
            var cultureInfo = CultureInfo.GetCultureInfo("en-US");
            var setEn = Localization.Home.ResourceManager.GetResourceSet(cultureInfo, true, true);
            foreach (DictionaryEntry row in setEn)
            {
                dictionary.Add(row.Key.ToString(), row.Value.ToString());
            }

            var json = JsonSerializer.Serialize(dictionary);
            //var result = $"= {json};";
            return Json(json);
        }

        public IActionResult Privacy()
        {
            var model = _homePresentation.GetMazeViewModel(5, 10);
            return View(model);
        }

        public IActionResult Maze()
        {
            var model = _homePresentation.GetMazeViewModel(10, 10);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }

        public IActionResult MazeCoreStructure()
        {
            var model = _homePresentation.GetMazeCoreStructure();
            return View(model);
        }
    }
}
