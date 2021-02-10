using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Controllers.CustomAttribute;
using WebApplication.Models;
using WebApplication.Models.Calendar;
using WebApplication.Presentation;

namespace WebApplication.Controllers
{
    [Authorize]
    [CustomLocalization]
    public class CalendarEventController : Controller
    {
        private CalendarEventPresentation _calendarEventPresentation;

        public CalendarEventController(CalendarEventPresentation calendarEventPresentation)
        {
            _calendarEventPresentation = calendarEventPresentation;
        }

        [Authorize(Roles = "Admin,AdminHelp")]
        public IActionResult Index(int page = 0, int pageSize = 5,
            SortColumn sortColumn = SortColumn.Id, SortDirection sortDirection = SortDirection.ASC
            )
        {
            var viewModel = _calendarEventPresentation.GetViewModelIndex(page, pageSize, sortColumn, sortDirection);
            return View(viewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,AdminHelp")]
        public IActionResult AddOrEdit(long id)
        {
            var viewModel = id == 0 
                  ? _calendarEventPresentation.GetCalendarEventViewModel()
                  : _calendarEventPresentation.GetCalendarEventViewModelByEventId(id);
            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,AdminHelp")]
        public IActionResult AddOrEdit(CalendarEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.CalendarTypeEvents = _calendarEventPresentation.GetCalendarTypeEventViewModels();
                return View(model);
            }
            _calendarEventPresentation.SaveCalendarEvent(model);
            return RedirectToAction("Index", "CalendarEvent");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddOrEditTypeEvent(long id)
        {
            var viewModel = id == 0 
                 ? new CalendarTypeEventViewModel()
                 : _calendarEventPresentation.GetCalendarTypeEventViewModelById(id);
            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddOrEditTypeEvent(CalendarTypeEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _calendarEventPresentation.SaveCalendarTypeEvent(model);
            return RedirectToAction("Index", "CalendarEvent");
        }

        [Authorize(Roles = "Admin,AdminHelp")]
        public IActionResult Remove(long id)
        {
            _calendarEventPresentation.RemoveCalendarEvent(id);
            return RedirectToAction("Index", "CalendarEvent");
        }

        [Authorize]
        public IActionResult GetCalendarEvents()
        {
            var message = _calendarEventPresentation.GetCalendarEvents();
            return Json(message);
        }

        [Authorize]
        public IActionResult GetChartData(int calendarEventYear)
        {
            var data = _calendarEventPresentation.GetChartData(calendarEventYear);
            return Json(data);
        }
    }
}
