using System.ComponentModel;
using WebApplication.Models.Calendar;


namespace WebApplication.Models
{
    public class ManageCalendarEventsViewModel
    {
        public CalendarEventViewModels CalendarEvents { get; set; }
        public CalendarEventViewModels CalendarPastEvents { get; set; }
        public CalendarEventViewModels CalendarComingEvents { get; set; }
        
        [DisplayName("Выбор года")]
        public CalendarEventYearViewModel CalendarEventYear { get; set;  }
    }
}
