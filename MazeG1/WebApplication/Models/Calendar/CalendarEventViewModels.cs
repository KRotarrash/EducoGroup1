using System.Collections.Generic;
using WebApplication.DbStuff.Model;

namespace WebApplication.Models.Calendar
{
    public class CalendarEventViewModels
    {
        public List<CalendarEventViewModel> CalendarEvents { get; set; }
        public SpecialUser CurrentUser { get; set; }
        public PaginatorInfoViewModel PaginatorInfo { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
