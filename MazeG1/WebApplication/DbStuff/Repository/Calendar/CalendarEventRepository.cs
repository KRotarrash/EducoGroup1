using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.DbStuff.Model.Calendar;
using WebApplication.DbStuff.Repository.IRepository.ICalendar;
using WebApplication.Service;

namespace WebApplication.DbStuff.Repository.Calendar
{
    public class CalendarEventRepository : BaseRepository<CalendarEvent>, ICalendarEventRepository
    {
        public CalendarEventRepository(WebContext webContext) : base(webContext) { }

        public override void Save(CalendarEvent model)
        {
            if (model.DateFinishEvent == new DateTime())
            {
                model.DateFinishEvent = model.DateStartEvent;
            }

            base.Save(model);
        }

        public IEnumerable<CalendarEvent> GetByDateRange(DateTime from, DateTime to)
        {
            return _dbSet.Where(x => x.DateStartEvent > from && x.DateStartEvent < to);
        }

        public CalendarEvent GetByTitleOfEvent(string name)
        {
            return _dbSet.FirstOrDefault(x => x.Title == name);
        }

        public IEnumerable<CalendarEvent> GetByYear(int calendarEventYear)
        {
            return _dbSet.Where(x => x.DateStartEvent.Year == calendarEventYear);
        }

        public IQueryable<int> GetUniqEventYears()
        {
            return _dbSet.Select(x => x.DateStartEvent.Year).Distinct();
        }
    }
}
