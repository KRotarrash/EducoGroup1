using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.EMMA;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.DbStuff.Model.Job;
using WebApplication.Models;
using WebApplication.Models.Job;
using WebApplication.Presentation;

namespace WebApplication.Controllers
{
    public class JobController : Controller
    {
        public JobPresentation _jodPresentation;
        public UserPresentation _userPresentation;


        public JobController(JobPresentation jobPresentation, UserPresentation userPresentation)
        {
            _jodPresentation = jobPresentation;
            _userPresentation = userPresentation;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var model = new JobViewModel()
            {
                JobViewModels = _jodPresentation.GetAllJobViewModel()
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult NewJob()
        {
            var model = new JobViewModel()
            {
                Organizations = _jodPresentation.GetAllOrganizationViewModels()
            };

           return View(model);
        }

        [HttpPost]
        public IActionResult NewJobSave(JobViewModel model)
        {
            _jodPresentation.SaveJob(model);
            return RedirectToAction("Index", "Job");
        }

        [HttpGet]
        public IActionResult EditJob(long jobId)
        {
            var model = _jodPresentation.GetJobViewModel(jobId);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditJob(JobViewModel model)
        {
            _jodPresentation.UpdateJob(model);
            return RedirectToAction("Index", "Job");
        }

        [HttpGet]
        public IActionResult NewOrganization()
        {
            var model = _jodPresentation.GetOrganizationViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult NewOrganizationSave(OrganizationViewModel model)
        {
            _jodPresentation.SaveNewOrganization(model);
            return RedirectToAction("Organizations", "Job");
        }

        public JsonResult OrganizationNameIsUniq(string orgName)
        {
            var result = _jodPresentation.OrganizationNameIsUniq(orgName);
            return Json(result);
        }

        public JsonResult PositionNameIsUniq(long organizationId, string positionName)
        {
            var result = _jodPresentation.OrganizationPositionIsUniq(organizationId, positionName);
            return Json(result);
        }        

        [HttpGet]
        public IActionResult EditOrganization(long id)
        {
            var model = _jodPresentation.GetOrganizationViewModel(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult EditOrganization(OrganizationViewModel model)
        {
            _jodPresentation.UpdateOrganization(model);

            if (model.JobId > 0)
            {
                return RedirectToAction("EditJob", "Job", new { jobId = model.JobId });
            }
            return RedirectToAction("Organizations", "Job");
        }

        [HttpPost]
        public IActionResult AddingOfficeToOrganization(OrganizationOfficesManagerViewModel model)
        {
            _jodPresentation.AddOfficeToOrganization(model);
            return RedirectToAction("OrganizationOfficesManager", "Job", new { organizationId = model.Id });
        }

        public IActionResult ExcludeOfficeFromOrganization(long organizationId, long officeId)
        {
            _jodPresentation.ExcludeOfficeFromOrganization(officeId);
            return RedirectToAction("OrganizationOfficesManager", "Job", new { organizationId = organizationId });
        }

        public IActionResult ChangeMainOffice(long organizationId, long officeId)
        {
            _jodPresentation.ChangeMainOffice(officeId);
            return RedirectToAction("OrganizationOfficesManager", "Job", new { organizationId = organizationId });
        }

        public JsonResult GetPositions(long id)
        {
            var result = _jodPresentation.GetPositions(id);
            return Json(result);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Vacancy(int page = 0, int pageSize = 5,
            SortColumn sortColumn = SortColumn.Id, SortDirection sortDirection = SortDirection.ASC
            )
        {
            var viewModel = _jodPresentation.GetAllVacancyViewModel(page, pageSize, sortColumn, sortDirection);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult GetJob(long jobId)
        {
            var model = _jodPresentation.GetVacancyViewModel(jobId);
            return View(model);
        }

        [HttpPost]
        public IActionResult GetJob(VacancyViewModel model)
        {
            _jodPresentation.UpdateVacancy(model);
            return RedirectToAction("Vacancy", "Job");
        }

        public IActionResult JobCandidate(long jobId, int page = 0, int pageSize = 5,
            SortColumn sortColumn = SortColumn.Id, SortDirection sortDirection = SortDirection.ASC
            )
        {
            var viewModel = _jodPresentation.GetViewModelCandidate(jobId, page, pageSize, sortColumn, sortDirection);
            if (viewModel == null)
                return RedirectToAction("AccessDenied", "User");
            else
                return View(viewModel);
        }

        public IActionResult ApproveCandidate(long userId, long jobId)
        {
            _jodPresentation.ApproveCandidate(userId, jobId);
            return RedirectToAction("Vacancy", "Job");
        }

        public IActionResult GetChartData()
        {
            var data = _jodPresentation.GetChartData();
            return Json(data);
        }

        [HttpPost]
        public async Task<IActionResult> MainImgAvatar(IFormFile mainImgUrl, OrganizationViewModel model)
        {
            _jodPresentation.MainPosterForOrgnization(mainImgUrl, model);
            return RedirectToAction("", "Job");
        }

        [Authorize(Roles = "Admin,AdminHelp")]
        public IActionResult Organizations(int page = 0, int pageSize = 5,
            SortColumn sortColumn = SortColumn.Id, SortDirection sortDirection = SortDirection.ASC
            )
        {
            var viewModel = _jodPresentation.GetViewModelOrganizations(page, pageSize, sortColumn, sortDirection);
            return View(viewModel);
        }

        public IActionResult OrganizationOfficesManager(long organizationId)
        {
            var viewModel = _jodPresentation.GetOrganizationOfficesManagerViewModel(organizationId);
            return View(viewModel);            
        }

        [HttpGet]
        public IActionResult Office()
        {
            var model = _jodPresentation.GetManagerOfficeViewModel();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddOffice()
        {
            var model = _jodPresentation.AddOffice();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddOffice(OfficeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(_jodPresentation.AddOffice());
            }

            _jodPresentation.AddOffice(model);

            return RedirectToAction("Office", "Job");
        }

        [HttpGet]
        public IActionResult EditOffice(long id)
        {
            var model = _jodPresentation.EditOffice(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateOffice(OfficeViewModel model)
        {
            _jodPresentation.UpdateOffice(model);

            return RedirectToAction("Office", "Job");
        }

        public IActionResult RemoveOffice(long id)
        {
            if (id > 0)
            {
                _jodPresentation.RemoveOffice(id);
            }

            return RedirectToAction("Office", "Job");
        }

    }
}