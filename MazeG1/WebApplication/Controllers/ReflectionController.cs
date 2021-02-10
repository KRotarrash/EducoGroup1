using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using System.Reflection;
using WebApplication.Presentation;

namespace WebApplication.Controllers
{    
    public class ReflectionController : Controller
    {
        public ReflectionPresentation _reflectionPresentation;
        public KeyClassesPresentation _keyClassesPresentation;

        public ReflectionController(KeyClassesPresentation keyClassesPresentation, ReflectionPresentation reflectionPresentation)
        {
            _keyClassesPresentation = keyClassesPresentation;
            _reflectionPresentation = reflectionPresentation;
        }
        public IActionResult Index()
        {
            var model = _reflectionPresentation.GetViewModelIndex();
            return View(model);
        }

        public IActionResult KeyClasses()
        {
            var model = _keyClassesPresentation.GetKeyClassViewModel();
            return View(model);
        }
    }
}