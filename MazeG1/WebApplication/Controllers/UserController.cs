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
    [Authorize]
    [CustomLocalization]
    public class UserController : Controller
    {
        private UserPresentation _userPresentation;
        private ISpecialUserRepository _specialUserRepository;
        private JobPresentation _jobPresentation;
        private AddressPresentation _addressPresentation;

        public UserController(UserPresentation userPresentation, ISpecialUserRepository specialUserRepository, JobPresentation jobPresentation, AddressPresentation addressPresentation)
        {
            _userPresentation = userPresentation;
            _specialUserRepository = specialUserRepository;
            _jobPresentation = jobPresentation;
            _addressPresentation = addressPresentation;
        }

        [Authorize(Roles = "Admin,AdminHelp")]
        public IActionResult Index(int page = 0, int pageSize = 5,
            SortColumn sortColumn = SortColumn.Id, SortDirection sortDirection = SortDirection.ASC
            )
        {
            var viewModel = _userPresentation.GetViewModelIndex(page, pageSize, sortColumn, sortDirection);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Profile()
        {
            var viewModel = _userPresentation.GetProfileViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Avatar(IFormFile avatarUrl)
        {
            _userPresentation.SaveAvatar(avatarUrl);
            return RedirectToAction("Profile");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Job()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var viewModel = _userPresentation.GetUserViewModelByUserId(id);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel model)
        {
            var user = _specialUserRepository.Get(model.Id);

            if (!ModelState.IsValid)
            {
                model.Organizations = _jobPresentation.GetAllOrganizationViewModels();
                model.PositionId = _jobPresentation.GetPositionId(user);
                model.OrganizationId = _jobPresentation.GetOrganizationId(user);

                model.Аddress = _addressPresentation.GetAddressViewModel(user);
                model.Аddresses = _addressPresentation.GetAddressesViewModel();

                return View(model);
            }

            _userPresentation.EditUser(model);
            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        public IActionResult ChangeRole(long id)
        {
            var model = _userPresentation.GetRoleViewModelByUserId(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult ChangeRole(RoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _userPresentation.SaveRole(model);
            return RedirectToAction("Index", "User");
        }

        public IActionResult Remove(long id)
        {
            _userPresentation.RemoveUser(id);
            return RedirectToAction("Index", "User");
        }

        public IActionResult Download(long id)
        {
            var user = _userPresentation.GetUser(id);
            var path = _userPresentation.GetXmlProfile(user);
            return PhysicalFile(path,
                "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                $"Profile-{user.Name}.docx");
        }

        public IActionResult DownloadDefault(string outputName = "smile")
        {
            var path = _userPresentation.GetRtfProfile(outputName);
            return PhysicalFile(path,
                "application/rtf",
                $"{outputName}.rtf");
        }

        public IActionResult IsUniqName(string name)
        {
            return Json(_userPresentation.IsUniqName(name));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AddLogin()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            var url = Request.Query["ReturnUrl"];

            var viewModel = new LoginViewModel()
            {
                ReturnUrl = url
            };

            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var modelError = GetLoginViewModelError(model);
            if (modelError != null)
            {
                return View(model);
            }

            var claimsPrincipal = _userPresentation.GetSignInClaimsUser(model);
            await HttpContext.SignInAsync(claimsPrincipal);

            if (string.IsNullOrEmpty(model.ReturnUrl))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(model.ReturnUrl);
            }
        }

        private LoginViewModel GetLoginViewModelError(LoginViewModel model)
        {
            var user = _userPresentation.GetUserByNameAndPass(model);
            if (user == null)
            {
                if (!_userPresentation.IsSignInByName(model))
                {
                    // пользователя с таким Логином не существует
                    ModelState.AddModelError(nameof(LoginViewModel.UserName), "Пользователя с таким логином не существует!");
                    return model;
                }

                if (!_userPresentation.IsNullPassword(model))
                {
                    // не верный Пароль для веденного Логина
                    ModelState.AddModelError(nameof(LoginViewModel.Password), "Неверный пароль!");
                    return model;
                }
            }
            if (_userPresentation.IsBlocked(user.Id))
            {
                var message = _userPresentation.GetErrorMessageBlockUser(model.UserName);
                // если пользователь заблокирован
                ModelState.AddModelError(nameof(LoginViewModel.Password), message);
                return model;
            }

            return null;
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTag(TagViewModel viewModel)
        {
            _userPresentation.AddTag(viewModel);
            return RedirectToAction("Edit", "User", new { id = viewModel.UserId });
        }

        public IActionResult GetChartData()
        {
            var data = _userPresentation.GetChartData();
            return Json(data);
        }

        [HttpGet]
        public IActionResult PartnerProfile(long partnerId)
        {
            var viewModel = _userPresentation.GetProfileViewModel(partnerId);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult MarriageRequest()
        {
            var viewmodel = _userPresentation.CreateMarriageRequest();
            return View(viewmodel);
        }

        [HttpPost]
        public IActionResult MarriageRequest(NotificationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _userPresentation.SaveMarriageRequest(model);
            return RedirectToAction("Profile", "User");
        }

        public IActionResult RequestAgree(long notificationId)
        {
            _userPresentation.RequestAgree(notificationId);
            return RedirectToAction("Profile", "User");
        }

        public IActionResult GetNotificationsNew()
        {
            var message = _userPresentation.GetNotifications(true);
            return Json(message);
        }

        public IActionResult GetNotificationsOld()
        {
            var message = _userPresentation.GetNotifications(false);
            return Json(message);
        }

        public IActionResult DivorceRequest()
        {
            _userPresentation.SaveDivorceRequest();
            return RedirectToAction("Profile", "User");
        }

        public IActionResult RequestReject(long notificationId)
        {
            _userPresentation.RequestReject(notificationId);
            return RedirectToAction("Profile", "User");
        }

        public IActionResult SeenNotification(long notificationId)
        {
            _userPresentation.SeenNotification(notificationId);
            return RedirectToAction("Profile", "User");
        }
    }
}

