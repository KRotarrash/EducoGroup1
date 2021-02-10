using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.DbStuff.Model.Calendar;

namespace WebApplication.DbStuff.Repository.IRepository.ICalendar
{
    public interface ICalendarEventRepository : IBaseRepository<CalendarEvent>
    {
        IEnumerable<CalendarEvent> GetByDateRange(DateTime from, DateTime to);

        CalendarEvent GetByTitleOfEvent(string name);

        IEnumerable<CalendarEvent> GetByYear(int calendarEventYear);

        IQueryable<int> GetUniqEventYears();
    }
}
