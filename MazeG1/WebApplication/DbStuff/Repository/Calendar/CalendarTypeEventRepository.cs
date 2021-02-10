using System.Linq;
using WebApplication.DbStuff.Model.Calendar;
using WebApplication.DbStuff.Repository.IRepository.ICalendar;

namespace WebApplication.DbStuff.Repository.Calendar
{
    public class CalendarTypeEventRepository : BaseRepository<CalendarTypeEvent>, ICalendarTypeEventRepository
    {
        public CalendarTypeEventRepository(WebContext webContext) : base(webContext) { }

        public CalendarTypeEvent GetByNameOfTypeEvent(string nameOfTypeEvent)
        {
            return _dbSet.FirstOrDefault(x => x.NameOfTypeEvent == nameOfTypeEvent);
        }
    }
}
