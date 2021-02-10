using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Repository;
using WebApplication.DbStuff.Repository.IRepository.IJob;
using WebApplication.Models;
using WebApplication.Models.Users;
using WebApplication.Service;

namespace WebApplication.Presentation
{
    public class UserPresentation
    {
        private ISpecialUserRepository _specialUserRepository;
        private IUserService _userService;
        private IAdressRepository _adressRepository;
        private IMapper _mapper;
        private ITagRepository _tagRepository;
        private ISpecialUserTagRepository _specialUserTagRepository;
        private FileProfileService _fileProfileService;
        private OpenXmlProfileService _openXmlProfileService;
        private IWebHostEnvironment _hostingEnvironment;
        private IOrganizationPositionRepository _organizationPositionRepository;
        private JobPresentation _jobPresentation;
        private ISpecialUserAddressRepository _specialUserAddressRepository;
        private AddressPresentation _addressPresentation;
        private IMarriageRepository _marriageRepository;
        private INotificationRepository _notificationRepository;

        public UserPresentation(ISpecialUserRepository specialUserRepository,
            IUserService userService,
            IAdressRepository adressRepository,
            IMapper mapper,
            ITagRepository tagRepository,
            ISpecialUserTagRepository specialUserTagRepository,
            FileProfileService fileProfileService,
            OpenXmlProfileService openXmlProfileService,
            IWebHostEnvironment hostingEnvironment,
            IOrganizationPositionRepository organizationPositionRepository,
            JobPresentation jobPresentation,
            ISpecialUserAddressRepository specialUserAddressRepository, 
            AddressPresentation addressPresentation,
            IMarriageRepository marriageRepository,
            INotificationRepository notificationRepository)
        {
            _specialUserRepository = specialUserRepository;
            _userService = userService;
            _adressRepository = adressRepository;
            _mapper = mapper;
            _tagRepository = tagRepository;
            _specialUserTagRepository = specialUserTagRepository;
            _fileProfileService = fileProfileService;
            _openXmlProfileService = openXmlProfileService;
            _hostingEnvironment = hostingEnvironment;
            _organizationPositionRepository = organizationPositionRepository;
            _jobPresentation = jobPresentation;
            _specialUserAddressRepository = specialUserAddressRepository;
            _addressPresentation = addressPresentation;
            _marriageRepository = marriageRepository;
            _notificationRepository = notificationRepository;
        }

        public ManageUsersViewModel GetViewModelIndex(int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection)
        {
            var users = _specialUserRepository
               .GetAll();
            users = Sort(users, sortColumn, sortDirection);

            users = users.Skip(page * pageSize)
                .Take(pageSize);

            var viewModel = GetManageUsersViewModel(users, page, pageSize, sortColumn, sortDirection);
            return viewModel;
        }

        private ManageUsersViewModel GetManageUsersViewModel(IEnumerable<SpecialUser> users,
            int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection)
        {
            return new ManageUsersViewModel()
            {
                Users = GetUserViewModels(users),
                CurrentUser = _userService.GetCurrentUser(),
                PaginatorInfo = GetPaginatorInfoViewModel(page, pageSize, sortColumn, sortDirection),
                SortViewModel = new SortViewModel(sortColumn, sortDirection)
            };
        }

        private PaginatorInfoViewModel GetPaginatorInfoViewModel(int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection)
        {
            return new PaginatorInfoViewModel()
            {
                Page = page,
                PageSize = pageSize,
                TotalRecordCount = _specialUserRepository.Count(),
                SortColumn = sortColumn,
                SortDirection = sortDirection,
            };
        }

        protected IQueryable<SpecialUser> Sort(IQueryable<SpecialUser> users,
            SortColumn sortColumn, SortDirection sortDirection)
        {
            var soreted = users.OrderBy(user => user.Id);

            users = sortColumn switch
            {
                SortColumn.Id => users.OrderBy(s => s.Id),
                SortColumn.Name => users.OrderBy(s => s.Name),
                SortColumn.Age => users.OrderBy(s => s.Age),
                SortColumn.Height => users.OrderBy(s => s.Height),
                SortColumn.AddressCount => users.OrderBy(s => s.Adresses.Count),
                SortColumn.Role => users.OrderBy(s => s.WebRole.ToString()),
                _ => users.OrderBy(s => s.Id),
            };
            if (sortDirection == SortDirection.DESC)
            {
                users = users.Reverse();
            }

            return users;
        }

        public async void SaveAvatar(IFormFile avatarUrl)
        {
            var wwwRootPath = _hostingEnvironment.WebRootPath;
            var currentUserId = _userService.GetCurrentUser().Id;
            var fileName = $"avatar-{currentUserId}.jpg";
            var path = Path.Combine(wwwRootPath, "avatar", fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await avatarUrl.CopyToAsync(fileStream);
            }
        }

        public List<UserViewModel> GetUserViewModels(IEnumerable<SpecialUser> users = null)
        {
            if (users == null)
            {
                users = _specialUserRepository.GetAll();
            }

            return _mapper.Map<List<UserViewModel>>(users.ToList());
        }

        public UserViewModel GetProfileViewModel()
        {
            var user = _userService.GetCurrentUser();
            var model = _mapper.Map<UserViewModel>(user);
            var partner = _specialUserRepository.GetPartnerByUserId(user.Id); 
            if (partner != null)
            {
                model.PartnerId = partner.Id;
                model.PartnerUserName = partner.Name;
            }
            return model;
        }

        public UserViewModel GetProfileViewModel(long id)
        {
            var user = _specialUserRepository.Get(id);
            var viewModel = _mapper.Map<UserViewModel>(user);
            viewModel.Аddress = _addressPresentation.GetAddressViewModel(user);
            var partner = _specialUserRepository.GetPartnerByUserId(id);
            if (partner != null)
            {
                viewModel.PartnerUserName = partner.Name;
            }
            return viewModel;
        }
        public UserViewModel GetUserViewModelByUserId(long Id)
        {
            var user = _specialUserRepository.Get(Id);
            var viewModel = _mapper.Map<UserViewModel>(user);

            viewModel.Organizations = _jobPresentation.GetAllOrganizationViewModels();
            viewModel.PositionId = _jobPresentation.GetPositionId(user);
            viewModel.OrganizationId = _jobPresentation.GetOrganizationId(user);

            viewModel.Аddress = _addressPresentation.GetAddressViewModel(user);
            viewModel.Аddresses = _addressPresentation.GetAddressesViewModel();

            return viewModel;
        }

        public SpecialUser GetUser(long Id)
        {
            return _specialUserRepository.Get(Id);
        }

        public bool IsBlocked(string name)
        {
            return _userService.IsBlocked(name);
        }

        public bool IsBlocked(long id)
        {
            return _userService.IsBlocked(id);
        }

        public string GetErrorMessageBlockUser(string name)
        {
            var user = _specialUserRepository.GetUserByName(name);

            if (user.EndBlocked == DateTime.MaxValue)
            {
                return "Эта учётная запись заблокирована навсегда.";
            }
            if (user.DateBlocked < user.EndBlocked)
            {
                return $"Эта учётная запись заблокирована до {user.EndBlocked}.";
            }

            throw new Exception("Ошибка проверки блокировки пользьзователя");
        }

        public void EditUser(UserViewModel model)
        {
            var user = _specialUserRepository.Get(model.Id);

            _jobPresentation.ChangeOrganizationAdnPosition(user, model);
            _addressPresentation.ChangeAddress(model.AddressId, user);

            _specialUserRepository.Save(user);
        }

        public void SaveAddress(AdressViewModel model)
        {
            var adress = _mapper.Map<Adress>(model);
            _adressRepository.Save(adress);
            var userAddress = new SpecialUserAddress();
            userAddress.Adress = adress;
            userAddress.User = GetUser(model.OwnerId);
            _specialUserAddressRepository.Save(userAddress);
        }

        public void RemoveUser(long Id)
        {
            _specialUserRepository.Remove(Id);
        }

        public RoleViewModel GetRoleViewModelByUserId(long Id)
        {
            var user = _specialUserRepository.Get(Id);
            return _mapper.Map<RoleViewModel>(user);
        }

        public void SaveRole(RoleViewModel model)
        {
            var user = _specialUserRepository.Get(model.OwnerId);
            user.WebRole = (WebRole)model.RoleId;
            _specialUserRepository.Save(user);
        }

        public ChartDataViewModel GetChartData()
        {
            var users = _specialUserRepository.GetAll().ToList();
            var names = users.Select(x => x.Name).ToList();
            var heights = users.Select(x => x.Height).ToList();
            var ages = users.Select(x => x.Age).ToList();
            return new ChartDataViewModel
            {
                Names = names,
                Heights = heights,
                Ages = ages
            };
        }

        public SpecialUser GetUserByNameAndPass(LoginViewModel model)
        {
            return _specialUserRepository.GetUserByNameAndPass(model.UserName, model.Password);
        }

        public bool IsSignInByName(LoginViewModel model)
        {
            var user = _specialUserRepository.GetUserByName(model.UserName);
            return user != null;
        }

        public bool IsNullPassword(LoginViewModel model)
        {
            var user = _specialUserRepository.GetUserByName(model.UserName);
            return user.Password == null;
        }

        public ClaimsPrincipal GetSignInClaimsUser(LoginViewModel model)
        {
            var user = _specialUserRepository.GetUserByNameAndPass(model.UserName, model.Password);
            // Строка в документе
            var page = new List<Claim>() {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.AuthenticationMethod, Startup.AuthMethod),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.WebRole.ToString()),
            };

            //Документ
            var сlaimsIdentity = new ClaimsIdentity(page, Startup.AuthMethod);
            // Список документов
            return new ClaimsPrincipal(сlaimsIdentity);
        }

        public bool IsUniqName(string name)
        {
            var user = _specialUserRepository.GetUserByName(name);
            return (user == null);
        }

        public string GetXmlProfile(SpecialUser user)
        {
            return _openXmlProfileService.GenerateProfile(user);
        }

        public string GetRtfProfile(string outputName)
        {
            return _fileProfileService.GetDefaultFile();
        }

        internal void AddTag(TagViewModel viewModel)
        {
            var user = _specialUserRepository.Get(viewModel.UserId);
            if (user.Tags.Any(x => x.Tag.Name == viewModel.TagName))
            {
                return;
            }

            var tag = _tagRepository.GetByName(viewModel.TagName)
                ?? new Tag
                {
                    Name = viewModel.TagName,
                    Users = new List<SpecialUserTag>()
                };

            var link = new SpecialUserTag()
            {
                User = user,
                Tag = tag
            };

            user.Tags.Add(link);

            _specialUserTagRepository.Save(link);
        }

        public NotificationViewModel CreateMarriageRequest()
        {
            var requestSender = _userService.GetCurrentUser();
            var users = _specialUserRepository.GetUsersToMarriage(requestSender.Id);
            var model = new NotificationViewModel()
            {
                RequestSenderId = requestSender.Id,
                RequestSenderName = requestSender.Name,
                Users = _mapper.Map<List<UserShortViewModel>>(users.ToList())
            };
            return model;
        }

        public void SaveMarriageRequest(NotificationViewModel model)
        {
            var user = _specialUserRepository.Get(model.UserId);
            var requestSender = _userService.GetCurrentUser();

            var notification = new Notification()
            {
                User = user,
                Type = TypeNotification.MarriageRequest,
                Status = StatusNotification.Unread,
                Content = "Запрос на заключение брака с " + requestSender.Name,
                RequestSender = requestSender,
            };

            _notificationRepository.Save(notification);
        }

        private List<NotificationViewModel> GetNotificationsForUser(long id, bool isNew)
        {
            var notifications = _notificationRepository.GetNotificationsForUser(id, isNew);
            var model = _mapper.Map<List<NotificationViewModel>>(notifications.ToList());
            return model;
        }

        public void RequestAgree(long notificationId)
        {
            var notification = _notificationRepository.Get(notificationId);

            if (notification.Type == TypeNotification.MarriageRequest)
            {
                AgreeMarriageRequest(notification);
            }
            else if(notification.Type == TypeNotification.DivorceRequest)
            {
                AgreeDivorceRequest(notification);
            }
            SetSeenForNotification(notification);
        }

        private void AgreeMarriageRequest(Notification notification)
        {
            var partner1 = _specialUserRepository.Get(notification.User.Id);
            var partner2 = _specialUserRepository.Get(notification.RequestSender.Id);
            partner1.PartnerId = partner2.Id;
            _specialUserRepository.Save(partner1);
            partner2.PartnerId = partner1.Id;
            _specialUserRepository.Save(partner2);

            // отправляем подтверждение
            var confirmation = new Notification()
            {
                User = notification.RequestSender,
                Type = TypeNotification.Confirmation,
                Status = StatusNotification.Unread,
                Content = "Пользователь " + notification.User.Name + " принял ваш запрос на заключение брака",
                RequestSender = notification.User,
            };
            _notificationRepository.Save(confirmation);

            // создаем новую запись в таблице браков
            var marriage = new Marriage()
            {
                Husband = partner1,
                Wife = partner2,
                DateStartMarriage = DateTime.Now.Date,
            };
            _marriageRepository.Save(marriage);
        }

        public List<NotificationViewModel> GetNotifications(bool isNew)
        {
            var user = _userService.GetCurrentUser();
            var notifications = GetNotificationsForUser(user.Id, isNew);
            return notifications;
        }

        public void SaveDivorceRequest()
        {
            var requestSender = _userService.GetCurrentUser();
            var user = _specialUserRepository.GetPartnerByUserId(requestSender.Id);

            var notification = new Notification()
            {
                User = user,
                Type = TypeNotification.DivorceRequest,
                Status = StatusNotification.Unread,
                Content = "Запрос на развод с " + requestSender.Name,
                RequestSender = requestSender,
            };

            _notificationRepository.Save(notification);
        }

        private void AgreeDivorceRequest(Notification notification)
        {
            var husband = _specialUserRepository.Get(notification.User.Id);
            var wife = _specialUserRepository.Get(notification.RequestSender.Id);
            husband.PartnerId = 0;
            _specialUserRepository.Save(husband);
            wife.PartnerId = 0;
            _specialUserRepository.Save(wife);

            var marriage = _marriageRepository.GetMarriage(husband.Id, wife.Id);
            marriage.DateFinishMarriage = DateTime.Now.Date;
            _marriageRepository.Save(marriage);
        }

        public void RequestReject(long notificationId)
        {
            var notification = _notificationRepository.Get(notificationId);

            // отправляем отказ
            var rejection = new Notification()
            {
                User = notification.RequestSender,
                Type = TypeNotification.Rejection,
                Status = StatusNotification.Unread,
                Content = "Пользователь " + notification.User?.Name + " отклонил ваш запрос",
                RequestSender = notification.User,
            };
            _notificationRepository.Save(rejection);

            SetSeenForNotification(notification);
        }

        public void SeenNotification(long notificationId)
        {
            var notification = _notificationRepository.Get(notificationId);
            SetSeenForNotification(notification);
        }

        private void SetSeenForNotification(Notification notification)
        {
            notification.Status = StatusNotification.Seen;
            _notificationRepository.Save(notification);
        }
    }
}
