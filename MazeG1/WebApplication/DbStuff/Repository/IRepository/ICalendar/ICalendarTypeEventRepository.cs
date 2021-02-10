using WebApplication.DbStuff.Model.Calendar;

namespace WebApplication.DbStuff.Repository.IRepository.ICalendar
{
    public interface ICalendarTypeEventRepository : IBaseRepository<CalendarTypeEvent>
    {
        CalendarTypeEvent GetByNameOfTypeEvent(string nameOfTypeEvent);
    }
}
