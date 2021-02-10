using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Controllers.CustomAttribute;
using WebApplication.Models;
using WebApplication.Presentation;
using WebApplication.DbStuff.Model.Job;
using WebApplication.DbStuff.Repository.IRepository.IJob;
using System.Linq;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Repository;
using AutoMapper;
using System;

namespace WebApplication.Controllers
{
    [IsPoliceman]
    [CustomLocalization]
    public class PoliceController : Controller
    {
        private UserPresentation _userPresentation;
        private PolicePresentation _policePresentation;

        public PoliceController(
            UserPresentation userPresentation, 
            PolicePresentation policePresentation)
        {
            _userPresentation = userPresentation;
            _policePresentation = policePresentation;
        }

        [HttpGet]
        public IActionResult ProfileRead(long id)
        {
            var viewModel = _userPresentation.GetProfileViewModel(id);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Users()
        {
            var model = _policePresentation.GetUserList();
            return View(model);
        }

        public JsonResult UserBlock(long id, DateTime dateBan)
        {
            if (id <= 0)
            {
                return Json(false);
            }

            _policePresentation.UserBlock(id, dateBan);
            return Json(true);
        }

        public IActionResult UserUnblock(long id)
        {
            if (id > 0)
            {
                _policePresentation.UserUnblock(id);
            }

            return RedirectToAction("Users", "Police");
        }
    }
}

