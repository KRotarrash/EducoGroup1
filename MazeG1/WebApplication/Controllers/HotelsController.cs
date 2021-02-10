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
    public class HotelsController : Controller
    {
        private HotelsPresentation _hotelPresentation;

        public HotelsController(HotelsPresentation hotelPresentation)
        {
            _hotelPresentation = hotelPresentation;
        }

        public IActionResult Index(int page = 0, int pageSize = 5,
                  SortColumn sortColumn = SortColumn.Id, SortDirection sortDirection = SortDirection.ASC
                  )
        {
            var viewModel = _hotelPresentation.GetViewModelIndex(page, pageSize, sortColumn, sortDirection);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var viewModel = _hotelPresentation.GetHotelViewModel(id);
            if (viewModel == null)
                return RedirectToAction("AccessDenied", "User");
            else
                return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(HotelViewModel model)
        {
            _hotelPresentation.SaveHotel(model);
            return RedirectToAction("Index", "Hotels");
        }

        [HttpGet]
        [HotelOwnerOrHelper]
        public IActionResult AddRoom(long hotelId)
        {
            var viewModel = _hotelPresentation.GetHotelRoomViewModel(hotelId);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddRoom(HotelRoomViewModel model)
        {
            _hotelPresentation.AddRoom(model);
            return RedirectToAction("Index", "Hotels");
        }

        [HttpGet]
        [HotelOwner]
        public IActionResult ChooseHelper(long hotelId)
        {
            var viewModel = _hotelPresentation.GetHotelHelperRoomViewModel(hotelId);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ChooseHelper(ManageHotelHelperViewModel model)
        {
            _hotelPresentation.SaveHelper(model);
            return RedirectToAction("Index", "Hotels");
        }

        public IActionResult AddHelper(long hotelId, long userId)
        {
            _hotelPresentation.AddHelper(hotelId, userId);
            return RedirectToAction("ChooseHelper", "Hotels", new { hotelId = hotelId });
        }

        public IActionResult DeleteHelper(long hotelId, long userId)
        {
            _hotelPresentation.DeleteHelper(hotelId, userId);
            return RedirectToAction("ChooseHelper", "Hotels", new { hotelId = hotelId });
        }

        [HttpGet]
        public IActionResult Booking(DateTime dtmStart, DateTime dtmFinish)
        {
            var viewModel = dtmStart == new DateTime() ? _hotelPresentation.GetHotelRoomBookingViewModel() : _hotelPresentation.GetHotelRoomBookingViewModel(dtmStart, dtmFinish);
            return View(viewModel);
        }

        public IActionResult BookRoom(long hotelRoomId, long userId, DateTime dtmStart, DateTime dtmFinish)
        {
            _hotelPresentation.BookRoom(hotelRoomId, userId, dtmStart, dtmFinish);
            return RedirectToAction("Index", "Hotels");
        }
    }
}