using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using System.Reflection;
using WebApplication.Presentation;
using Microsoft.AspNetCore.Authorization;
using WebApplication.Controllers.CustomAttribute;

namespace WebApplication.Controllers
{
    [Authorize]
    [IsDoctor]
    public class HospitalController : Controller
    {
        private HospitalPresentation _hospitalPresentation;

        public HospitalController(HospitalPresentation hospitalPresentation)
        {
            _hospitalPresentation = hospitalPresentation;
        }

        public IActionResult Index(int page = 0, int pageSize = 5,
            SortColumn sortColumn = SortColumn.Id, SortDirection sortDirection = SortDirection.ASC
            )
        {
            var viewModel = _hospitalPresentation.GetViewModelIndex(page, pageSize, sortColumn, sortDirection);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult EditDetail(long Id)
        {
            var viewModel = _hospitalPresentation.GetRecordViewModel(Id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditDetail(MedicalRecordDetailViewModel model)
        {
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _hospitalPresentation.SaveDetail(model);
            return RedirectToAction("Index", "Hospital");
        }

        [HttpGet]
        public IActionResult ViewRecord(long Id, int page = 0, int pageSize = 5,
            SortColumn sortColumn = SortColumn.Id, SortDirection sortDirection = SortDirection.ASC)
        {
            var viewModel = _hospitalPresentation.GetViewRecordViewModel(Id, page, pageSize, sortColumn, sortDirection);
            return View(viewModel);
        }

        public IActionResult RemoveRecord(long id)
        {
            _hospitalPresentation.RemoveRecord(id);
            return RedirectToAction("Index", "Hospital");
        }

        public IActionResult RemoveDetail(long id)
        {
            _hospitalPresentation.RemoveDetail(id);
            return RedirectToAction("Index", "Hospital");
        }

        public IActionResult GetChartData(long Id)
        {
            var data = _hospitalPresentation.GetChartData(Id);
            return Json(data);
        }
    }
}