using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Controllers.CustomAttribute;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Repository;
using WebApplication.Localization;
using WebApplication.Models;
using WebApplication.Presentation;
using WebApplication.Sevrice;

namespace WebApplication.Controllers
{
    [Authorize]
    [CustomLocalization]
    [IsMayor]
    public class AddressController : Controller
    {
        private IAdressRepository _adressRepository;
        private AddressPresentation _addressPresentation;

        public AddressController(IAdressRepository adressRepository,
            AddressPresentation addressPresentation)
        {
            _adressRepository = adressRepository;
            _addressPresentation = addressPresentation;
        }

        [Authorize(Roles = "Admin,AdminHelp")]
        public IActionResult Index(int page = 0, int pageSize = 5,
            SortColumn sortColumn = SortColumn.Id, SortDirection sortDirection = SortDirection.ASC
            )
        {
            var viewModel = _addressPresentation.GetViewModelIndex(page, pageSize, sortColumn, sortDirection);
            return View(viewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,AdminHelp")]
        public IActionResult Add()
        {
            return View(new AdressViewModel());
        }

        [HttpPost]
        public IActionResult Add(AdressViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _addressPresentation.AddNewAddress(model);
            return RedirectToAction("Index", "Address");
        }

        public IActionResult Remove(long id)
        {
            _adressRepository.Remove(id);
            return RedirectToAction("Index", "Address");
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var viewModel = _addressPresentation.GetEditViewModel(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(AdressViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _addressPresentation.ChangeAddress(model);
            return RedirectToAction("Index", "Address");
        }

        public IActionResult GetChartData()
        {
            var data = _addressPresentation.GetChartData();
            return Json(data);
        }
    }
}

