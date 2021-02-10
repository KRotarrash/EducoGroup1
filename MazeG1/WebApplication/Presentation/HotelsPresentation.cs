using AutoMapper;
using DbFile.Model;
using MazeCore;
using MazeCore.CellStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Model.Hotels;
using WebApplication.DbStuff.Repository;
using WebApplication.DbStuff.Repository.IRepository.IHotels;
using WebApplication.DbStuff.Repository.IRepository.ICalendar;
using WebApplication.Models;
using WebApplication.Service;
using WebApplication.Sevrice;
using WebApplication.DbStuff.Model.Calendar;

namespace WebApplication.Presentation
{
    public class HotelsPresentation
    {
        private IHotelRepository _hotelRepository;
        private IHotelRoomRepository _hotelRoomRepository;
        private IMapper _mapper;
        private ISpecialUserRepository _specialUserRepository;
        private IUserService _userService;
        private IHotelRoomBookingRepository _hotelRoomBookingRepository;
        private ICalendarEventRepository _calendarEventRepository;
        private ISpecialUserCalendarEventRepository _specialUserCalendarEventRepository;
        private ICalendarTypeEventRepository _calendarTypeEventRepository;

        public HotelsPresentation(IHotelRepository hotelRepository,
           IMapper mapper, ISpecialUserRepository specialUserRepository, IHotelRoomRepository hotelRoomRepository,
           IUserService userService,
           IHotelRoomBookingRepository hotelRoomBookingRepository, 
           ICalendarEventRepository calendarEventRepository,
           ISpecialUserCalendarEventRepository specialUserCalendarEventRepository,
           ICalendarTypeEventRepository calendarTypeEventRepository)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
            _specialUserRepository = specialUserRepository;
            _hotelRoomRepository = hotelRoomRepository;
            _userService = userService;
            _hotelRoomBookingRepository = hotelRoomBookingRepository;
            _calendarEventRepository = calendarEventRepository;
            _specialUserCalendarEventRepository = specialUserCalendarEventRepository;
            _calendarTypeEventRepository = calendarTypeEventRepository;
        }

        public ManageHotelViewModel GetViewModelIndex(int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection)
        {
            var hotels = _hotelRepository
               .GetAll();
            hotels = Sort(hotels, sortColumn, sortDirection);

            hotels = hotels.Skip(page * pageSize)
                .Take(pageSize);

            var viewModel = GetManageHotelViewModel(hotels, page, pageSize, sortColumn, sortDirection);
            return viewModel;
        }

        private ManageHotelViewModel GetManageHotelViewModel(IEnumerable<Hotel> hotels,
            int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection)
        {
            return new ManageHotelViewModel()
            {
                Hotels = GetHotelViewModels(hotels),
                PaginatorInfo = GetPaginatorInfoViewModel(page, pageSize, sortColumn, sortDirection),
                SortViewModel = new SortViewModel(sortColumn, sortDirection)
            };
        }

        public List<HotelViewModel> GetHotelViewModels(IEnumerable<Hotel> hotels = null)
        {
            if (hotels == null)
            {
                hotels = _hotelRepository.GetAll();
            }

            return _mapper.Map<List<HotelViewModel>>(hotels.ToList());
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

        protected IQueryable<Hotel> Sort(IQueryable<Hotel> hotels,
            SortColumn sortColumn, SortDirection sortDirection)
        {
            var soreted = hotels.OrderBy(user => user.Id);

            hotels = sortColumn switch
            {
                SortColumn.Id => hotels.OrderBy(s => s.Id),
                SortColumn.HotelName => hotels.OrderBy(s => s.Name),
                SortColumn.Name => hotels.OrderBy(s => s.Owner.Name),
                SortColumn.RoomCount => hotels.OrderBy(s => s.Rooms.Count()),
                _ => hotels.OrderBy(s => s.Id),
            };
            if (sortDirection == SortDirection.DESC)
            {
                hotels = hotels.Reverse();
            }

            return hotels;
        }

        public void SaveHotel(HotelViewModel model)
        {
            var hotel = _mapper.Map<Hotel>(model);
            hotel.Owner = _specialUserRepository.Get(model.OwnerId);
            _hotelRepository.Save(hotel);
        }

        public HotelViewModel GetHotelViewModel(long id)
        {
            var hotel = _hotelRepository.Get(id);
            if (hotel != null && (hotel.Owner == null || _userService.GetCurrentUser().Id != hotel.Owner.Id))
            {
                return null;
            }

            HotelViewModel model;
            if (id == 0)
            {
                var users = _specialUserRepository.GetAll();
                model = new HotelViewModel()
                {
                    Users = _mapper.Map<List<UserViewModel>>(users.ToList())
                };
            }
            else
            {
                model = GetHotelViewModelById(id);
            }

            return model;
        }

        public HotelViewModel GetHotelViewModelById(long Id)
        {
            var hotel = _hotelRepository.Get(Id);
            var viewModel = _mapper.Map<HotelViewModel>(hotel);

            var users = _specialUserRepository.GetAll();
            viewModel.Users = _mapper.Map<List<UserViewModel>>(users.ToList());

            return viewModel;
        }

        public HotelRoomViewModel GetHotelRoomViewModel(long hotelId)
        {
            var hotel = _hotelRepository.Get(hotelId);
            return new HotelRoomViewModel()
            {
                Hotel = _mapper.Map<HotelViewModel>(hotel)
            };
        }

        public void AddRoom(HotelRoomViewModel model)
        {
            var hotel = _hotelRepository.Get(model.Hotel.Id);
            var room = _mapper.Map<HotelRoom>(model);
            room.Hotel = hotel;
            hotel.Rooms.Add(room);
         
            _hotelRoomRepository.Save(room);
        }

        public ManageHotelHelperViewModel GetHotelHelperRoomViewModel(long hotelId)
        {
            var hotel = _hotelRepository.Get(hotelId);
            
            var helperIds = _specialUserRepository.GetUserIdsWhoHelperForOtherHotels(hotelId).ToList();
            var users = _specialUserRepository.GetAll()
                .Where(x => !helperIds.Contains(x.Id) && x.Id != hotel.Owner.Id);
            var usersModels = _mapper.Map<List<UserViewModel>>(users.ToList());
            var helpers = new List<HelperViewModel>();

            var checkedUsers = new List<long>();

            foreach (var userModel in usersModels)
            {
                var isHelper = _specialUserRepository.IsUserIsHelperForHotel(userModel.Id, hotelId);
                if (isHelper)
                {
                    checkedUsers.Add(userModel.Id);
                }

                var helper = new HelperViewModel()
                {
                    IsHelper = isHelper,
                    Helper = userModel,
                    HotelId = hotelId,
                };

                helpers.Add(helper);
            }
            var hotelHelpers = new ManageHotelHelperViewModel()
            {
                HotelId = hotelId,
                Helpers = helpers,
                CheckedUsers = checkedUsers,
            };

            return hotelHelpers;
        }

        public void SaveHelper(ManageHotelHelperViewModel model)
        {
            var helpersModels = new List<HelperViewModel>();
            foreach (var modelHelper in model.Helpers)
            {
                if (!modelHelper.IsHelper)
                    continue;
                helpersModels.Add(modelHelper); 
            }
            
            var hotel = _hotelRepository.Get(model.HotelId);
            var hotelHelpers = _mapper.Map<List<SpecialUser>>(helpersModels.ToList());
            hotel.Helpers.Clear();
            hotel.Helpers.AddRange(hotelHelpers);
            _hotelRepository.Save(hotel);
        }

        public void AddHelper(long hotelId, long userId)
        {
            var hotel = _hotelRepository.Get(hotelId);
            var user = _specialUserRepository.Get(userId);
            hotel.Helpers.Add(user);
            _hotelRepository.Save(hotel);
        }

        public void DeleteHelper(long hotelId, long userId)
        {
            var hotel = _hotelRepository.Get(hotelId);
            var user = _specialUserRepository.Get(userId);
            hotel.Helpers.Remove(user);
            _hotelRepository.Save(hotel);
        }

        public HotelRoomBookingViewModel GetHotelRoomBookingViewModel()
        {
            var model = new HotelRoomBookingViewModel()
            {
                DateStart = DateTime.Now,
                DateFinish = DateTime.Now.AddDays(1),
                HotelRooms = new List<HotelRoomViewModel>(),
                User = _mapper.Map<UserViewModel>(_userService.GetCurrentUser()),
            };
            return model;
        }

        public HotelRoomBookingViewModel GetHotelRoomBookingViewModel(DateTime dtmStart, DateTime dtmFinish)
        {
            var bookingIds = _hotelRoomBookingRepository.GetHotelRoomIdsBookingForDate(dtmStart, dtmFinish);

            var freeRooms = _hotelRoomRepository.GetAll()
                .Where(x => !bookingIds.Contains(x.Id));

            var model = new HotelRoomBookingViewModel()
            {
                DateStart = dtmStart,
                DateFinish = dtmFinish,
                HotelRooms = _mapper.Map<List<HotelRoomViewModel>>(freeRooms.ToList()),
                User = _mapper.Map<UserViewModel>(_userService.GetCurrentUser()),
            };
            return model;
        }

        public void BookRoom(long hotelRoomId, long userId, DateTime dtmStart, DateTime dtmFinish)
        {
            var hotelRoom = _hotelRoomRepository.Get(hotelRoomId);
            var user = _specialUserRepository.Get(userId);

            var booking = new HotelRoomBooking()
            {
                HotelRoom = hotelRoom,
                User = user,
                DateStart = dtmStart.Date,
                DateFinish = dtmFinish.Date
            };

            SaveBookingInCalendar(booking, user);
            _hotelRoomBookingRepository.Save(booking);
        }

        private void SaveBookingInCalendar(HotelRoomBooking booking, SpecialUser user)
        {
            var calendarEvent = new CalendarEvent()
            {
                Title = "Бронирование",
                Description = $"Бронирование в отеле \"{booking.HotelRoom.Hotel.Name}\"",
                DateStartEvent = booking.DateStart, 
                DateFinishEvent = booking.DateFinish,
                CalendarTypeEvent = _calendarTypeEventRepository.GetByNameOfTypeEvent(HostSeed.NameOfTypeEventBooking)
        };

            var userCalendarEvent = new SpecialUserCalendarEvent()
            {
                User = user,
                CalendarEvent = calendarEvent
            };
            _specialUserCalendarEventRepository.Save(userCalendarEvent);
        }
    }
}
