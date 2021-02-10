using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Calendar
{
    public class CalendarEventChartDataViewModel
    {
        public int CountEvents { get; set; }
        public int CountEventsStep { get; set; }
        public List<int> CountEventsByMonth { get; set; }
    }
}
