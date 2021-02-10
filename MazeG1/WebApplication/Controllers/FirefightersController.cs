using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Controllers.CustomAttribute;
using WebApplication.Models;
using WebApplication.Models.Firefighters;
using WebApplication.Presentation;

namespace WebApplication.Controllers
{
    /// <summary>
    /// Служба пажаротушения
    /// </summary>
    [IsFirefighter]
    [CustomLocalization]
    public class FirefightersController : Controller
    {
        private FirefightersPresentation _firefightersPresentation;

        public FirefightersController(FirefightersPresentation fireInspectionBuildingPresentation)
        {
            _firefightersPresentation = fireInspectionBuildingPresentation;
        }

        public IActionResult Index(int page = 0, int pageSize = 5, SortColumn sortColumn = SortColumn.Id, SortDirection sortDirection = SortDirection.ASC)
        {
            var viewModel = _firefightersPresentation.GetViewModelIndex(page, pageSize, sortColumn, sortDirection);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AddOrEdit(long id)
        {
            var viewModel = _firefightersPresentation.GetFireInspectionBuildingViewModelById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddOrEdit(FireInspectionBuildingAddOrEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.BuildingAdresses = _firefightersPresentation
                     .GetBuildingAdressesViewModel();
                model.BuildingTypeSafetyAssessments = _firefightersPresentation
                    .GetBuildingTypeSafetyAssessmentsViewModel();
                return View(model);
            }
            _firefightersPresentation.SaveFireInspectionBuilding(model);
            return RedirectToAction("Index", "Firefighters");
        }

        public IActionResult Remove(long id)
        {
            _firefightersPresentation.RemoveFireInspectionBuilding(id);
            return RedirectToAction("Index", "Firefighters");
        }

        [HttpGet]
        public IActionResult AddOrEditSchedule(long id)
        {
            var viewModel = _firefightersPresentation.GetFireInspectionScheduleViewModelById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddOrEditSchedule(FireInspectionScheduleAddOrEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.BuildingAdresses = _firefightersPresentation
                     .GetBuildingAdressesViewModel();
                return View(model);
            }
            _firefightersPresentation.SaveFireInspectionSchedule(model);
            return RedirectToAction("Index", "Firefighters");
        }

        public IActionResult RemoveSchedule(long id)
        {
            _firefightersPresentation.RemoveFireInspectionSchedule(id);
            return RedirectToAction("Index", "Firefighters");
        }

        [HttpGet]
        public IActionResult AddOrEditTypeSafety(long id)
        {
            var viewModel = _firefightersPresentation.GetBuildingTypeSafetyAssessmentViewModelById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddOrEditTypeSafety(BuildingTypeSafetyAssessmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _firefightersPresentation.SaveBuildingTypeSafetyAssessment(model);
            return RedirectToAction("Index", "Firefighters");
        }

        public IActionResult GetChartData(int fireInspectionBuildingYear)
        {
            var data = _firefightersPresentation.GetChartData(fireInspectionBuildingYear);
            return Json(data);
        }
    }
}
