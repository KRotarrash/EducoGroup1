using WebApplication.DbStuff.Model.Calendar;
using WebApplication.DbStuff.Repository.IRepository.ICalendar;

namespace WebApplication.DbStuff.Repository.Calendar
{
    public class SpecialUserCalendarEventRepository : BaseRepository<SpecialUserCalendarEvent>, ISpecialUserCalendarEventRepository
    {
        public SpecialUserCalendarEventRepository(WebContext webContext) : base(webContext) { }
    }
}
