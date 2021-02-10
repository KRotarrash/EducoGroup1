using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.DbStuff;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Model.Calendar;
using WebApplication.DbStuff.Repository.IRepository.ICalendar;
using WebApplication.Models;
using WebApplication.Models.Calendar;
using WebApplication.Service;

namespace WebApplication.Presentation
{
    public class CalendarEventPresentation
    {
        private ICalendarEventRepository _calendarEventRepository;
        private ISpecialUserCalendarEventRepository _specialUserCalendarEventRepository;
        private ICalendarTypeEventRepository _calendarTypeEventRepository;
        private IUserService _userService;
        private IMapper _mapper;

        private const int _dayEvents = 3;
        private const int _countMonth = 12;
        private const int _scaleMaxCountEvents = 20;


        public CalendarEventPresentation(
            ICalendarEventRepository calendarEventRepository,
            ISpecialUserCalendarEventRepository specialUserCalendarEventRepository,
            ICalendarTypeEventRepository calendarTypeEventRepository,
            IUserService userService,
            IMapper mapper)
        {
            _calendarEventRepository = calendarEventRepository;
            _specialUserCalendarEventRepository = specialUserCalendarEventRepository;
            _calendarTypeEventRepository = calendarTypeEventRepository;
            _userService = userService;
            _mapper = mapper;
        }

        public ManageCalendarEventsViewModel GetViewModelIndex(int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection)
        {
            var viewModel = new ManageCalendarEventsViewModel()
            {
                CalendarEvents = GetListCalendarEventViewModel(page, pageSize, sortColumn, sortDirection,
                    DateTime.Now.AddDays(-_dayEvents), DateTime.Now.AddDays(_dayEvents)),
                CalendarPastEvents = GetListCalendarEventViewModel(page, pageSize, sortColumn, sortDirection,
                    DateTime.MinValue, DateTime.Now),
                CalendarComingEvents = GetListCalendarEventViewModel(page, pageSize, sortColumn, sortDirection,
                    DateTime.Now, DateTime.MaxValue),
                CalendarEventYear = GetCalendarEventYears()
            };
            return viewModel;
        }

        private CalendarEventViewModels GetListCalendarEventViewModel(int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection,
              DateTime from, DateTime to)
        {
            var calendarEvents = _calendarEventRepository.GetByDateRange(from, to);
            var eventsTotalRecordCount = calendarEvents.Count();
            calendarEvents = SortAndTakePage(calendarEvents, page, pageSize, sortColumn, sortDirection);

            var viewModel = new CalendarEventViewModels()
            {
                CalendarEvents = GetCalendarEventViewModels(calendarEvents),
                CurrentUser = _userService.GetCurrentUser(),
                PaginatorInfo = GetPaginatorInfoViewModel(eventsTotalRecordCount, page, pageSize, sortColumn, sortDirection),
                SortViewModel = new SortViewModel(sortColumn, sortDirection)
            };
            return viewModel;
        }

        private IEnumerable<CalendarEvent> SortAndTakePage(IEnumerable<CalendarEvent> calendarEvents, int page,
            int pageSize, SortColumn sortColumn, SortDirection sortDirection)
        {
            calendarEvents = Sort(calendarEvents, sortColumn, sortDirection);
            calendarEvents = calendarEvents.Skip(page * pageSize)
                    .Take(pageSize);
            return calendarEvents;
        }

        private PaginatorInfoViewModel GetPaginatorInfoViewModel(int eventsTotalRecordCount,
              int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection)
        {
            return new PaginatorInfoViewModel()
            {
                Page = page,
                PageSize = pageSize,
                TotalRecordCount = eventsTotalRecordCount,
                SortColumn = sortColumn,
                SortDirection = sortDirection,
            };
        }

        protected IEnumerable<CalendarEvent> Sort(IEnumerable<CalendarEvent> calendarEvents,
            SortColumn sortColumn, SortDirection sortDirection)
        {
            calendarEvents = sortColumn switch
            {
                SortColumn.Id => calendarEvents.OrderBy(s => s.Id),
                SortColumn.Title => calendarEvents.OrderBy(s => s.Title),
                SortColumn.Description => calendarEvents.OrderBy(s => s.Description),
                SortColumn.NameOfTypeEvent => calendarEvents.OrderBy(s => s.CalendarTypeEvent.NameOfTypeEvent),
                SortColumn.DateEvent => calendarEvents.OrderBy(s => s.DateStartEvent)
            };
            if (sortDirection == SortDirection.DESC)
            {
                calendarEvents = calendarEvents.Reverse();
            }
            return calendarEvents;
        }

        public void SaveCalendarEvent(CalendarEventViewModel model)
        {
            var calendarEvent = _mapper.Map<CalendarEvent>(model);
            var calendarTypeEvent = _calendarTypeEventRepository.Get(model.CalendarTypeEvent.Id);
            calendarEvent.CalendarTypeEvent = calendarTypeEvent;
            _calendarEventRepository.Save(calendarEvent);
            IgnoreCalendarEventCurrentUserIfPast(calendarEvent.Id);
        }

        public void RemoveCalendarEvent(long Id)
        {
            _calendarEventRepository.Remove(Id);
        }

        public CalendarEventViewModel GetCalendarEventViewModel()
        {
            return new CalendarEventViewModel()
            {
                CalendarTypeEvent = GetCalendarTypeEventViewModelDefault(),
                CalendarTypeEvents = GetCalendarTypeEventViewModels()
            };
        }

        private List<CalendarEventViewModel> GetCalendarEventViewModels(IEnumerable<CalendarEvent> calendarEvents = null)
        {
            if (calendarEvents == null)
            {
                calendarEvents = _calendarEventRepository.GetAll();
            }
            return _mapper.Map<List<CalendarEventViewModel>>(calendarEvents.ToList());
        }

        public CalendarEventViewModel GetCalendarEventViewModelByEventId(long Id)
        {
            var calendarEvent = _calendarEventRepository.Get(Id);
            var viewModel = _mapper.Map<CalendarEventViewModel>(calendarEvent);
            viewModel.CalendarTypeEvents = GetCalendarTypeEventViewModels();
            return viewModel;
        }

        public List<CalendarTypeEventViewModel> GetCalendarTypeEventViewModels(IEnumerable<CalendarTypeEvent> calendarTypeEvents = null)
        {
            if (calendarTypeEvents == null)
            {
                calendarTypeEvents = _calendarTypeEventRepository.GetAll();
            }
            return _mapper.Map<List<CalendarTypeEventViewModel>>(calendarTypeEvents.ToList());
        }

        public CalendarTypeEventViewModel GetCalendarTypeEventViewModelById(long id)
        {
            var calendarTypeEvent = _calendarTypeEventRepository.Get(id);
            var viewModel = _mapper.Map<CalendarTypeEventViewModel>(calendarTypeEvent);
            return viewModel;
        }

        private CalendarTypeEventViewModel GetCalendarTypeEventViewModelDefault()
        {
            var calendarTypeEvent = _calendarTypeEventRepository
                   .GetByNameOfTypeEvent(HostSeed.NameOfTypeEventDefault);
            var viewModel = _mapper.Map<CalendarTypeEventViewModel>(calendarTypeEvent);
            return viewModel;
        }

        public void SaveCalendarTypeEvent(CalendarTypeEventViewModel model)
        {
            var calendarTypeEvent = _mapper.Map<CalendarTypeEvent>(model);
            _calendarTypeEventRepository.Save(calendarTypeEvent);
        }

        public List<string> GetCalendarEvents()
        {
            var user = _userService.GetCurrentUser();
            if (user == null)
            {
                return new List<string>();
            }

            var unseenCalendarEvents = GetUnseenCalendarEvents()
                .ToList();
            foreach (var calendarEvent in unseenCalendarEvents)
            {
                SaveCalendarEventForSpecialUser(user, calendarEvent);
            }
            return unseenCalendarEvents.Select(x => x.Title).ToList();
        }

        private void IgnoreCalendarEventCurrentUserIfPast(long calendarEventId)
        {
            var user = _userService.GetCurrentUser();
            if (user == null)
            {
                return;
            }

            var unseenCalendarEvent = GetUnseenCalendarEvents(calendarEventId)
                .FirstOrDefault();
            if (unseenCalendarEvent == null)
            {
                return;
            }
            SaveCalendarEventForSpecialUser(user, unseenCalendarEvent);
        }

        private IEnumerable<CalendarEvent> GetUnseenCalendarEvents(long calendarEventId = -1)
        {
            var user = _userService.GetCurrentUser();
            if (user == null)
            {
                return new List<CalendarEvent>();
            }

            var seenCalendarEventIds = user.SeenCalendarEvents
                .Select(x => new { Id = x.CalendarEvent.Id, Date = x.CalendarEvent.DateStartEvent }).Distinct().ToArray();
            var unseenCalendarEvents = _calendarEventRepository.GetAll()
                .Where(x => !seenCalendarEventIds.Select(x => x.Id).Contains(x.Id))
                .Where(x => (x.Id == calendarEventId || calendarEventId == -1) && x.DateStartEvent < DateTime.Now);
            return unseenCalendarEvents;
        }

        private void SaveCalendarEventForSpecialUser(SpecialUser user, CalendarEvent calendarEvent)
        {
            var link = new SpecialUserCalendarEvent()
            {
                User = user,
                CalendarEvent = calendarEvent
            };
            _specialUserCalendarEventRepository.Save(link);
        }

        public CalendarEventChartDataViewModel GetChartData(int calendarEventYear)
        {
            var countEventsByMonth = new List<int>();
            for (int i = 0; i < _countMonth; i++)
            {
                countEventsByMonth.Add(0);
            }

            _calendarEventRepository
                 .GetByYear(calendarEventYear)
                 .Select(x => x.DateStartEvent)
                 .ToList()
                 .ForEach(x => countEventsByMonth[x.Month - 1]++);

            var countEventsStep = GetEventsStep(countEventsByMonth);
            var countEvents = countEventsByMonth.Max(x => x);

            countEvents = countEvents % _scaleMaxCountEvents == 0 || countEvents < _scaleMaxCountEvents
                ? countEvents + countEventsStep
                : countEvents;

            return new CalendarEventChartDataViewModel
            {
                CountEvents = countEvents,
                CountEventsStep = countEventsStep,
                CountEventsByMonth = countEventsByMonth
            };
        }

        private int GetEventsStep(List<int> countEventsByMonth)
        {
            var maxCountEventsByMonth = countEventsByMonth.Max(x => x);
            double dMaxCountEventsByMonth = maxCountEventsByMonth;
            double step = (double)dMaxCountEventsByMonth / _scaleMaxCountEvents;

            return step < 1
                 ? 1
                 : maxCountEventsByMonth / (int)_scaleMaxCountEvents + 1;
        }

        private CalendarEventYearViewModel GetCalendarEventYears()
        {
            var calendarEventYears = _calendarEventRepository
                 .GetUniqEventYears()
                 .ToList();

            return new CalendarEventYearViewModel
            {
                Years = calendarEventYears
            };
        }
    }
}
