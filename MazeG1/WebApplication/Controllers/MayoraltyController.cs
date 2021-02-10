using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Presentation;
using Microsoft.AspNetCore.Authorization;
using WebApplication.Controllers.CustomAttribute;
using WebApplication.DbStuff;

namespace WebApplication.Controllers
{
    [Authorize]
    [IsMayor]
    public class MayoraltyController : Controller
    {
        private MayoraltyPresentation _mayoraltyPresentation;

        public MayoraltyController(MayoraltyPresentation mayoraltyPresentation)
        {
            _mayoraltyPresentation = mayoraltyPresentation;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult HospitalHead()
        {
            var model = _mayoraltyPresentation.GetOrganizationViewModel(HostSeed.HospitalNameDefault);
            return View(model);
        }

        [HttpPost]
        public IActionResult HospitalHead(OrganizationViewModel model)
        {
            _mayoraltyPresentation.UpdateOrganizationForUserViewModel(model, HostSeed.HospitalPositionDefault);
            return RedirectToAction("Index", "Mayoralty");
        }

        [HttpGet]
        public IActionResult FirefightersHead()
        {
            var model = _mayoraltyPresentation.GetOrganizationViewModel(HostSeed.FirefightersOrganizationDefault);
            return View(model);
        }

        [HttpPost]
        public IActionResult FirefightersHead(OrganizationViewModel model)
        {
            _mayoraltyPresentation.UpdateOrganizationForUserViewModel(model, HostSeed.FirefightersPositionDefault);
            return RedirectToAction("Index", "Mayoralty");
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        public IActionResult AddUserAjax(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(false);
            }

            _mayoraltyPresentation.SaveUser(model);

            return Json(true);
        }
    }
}