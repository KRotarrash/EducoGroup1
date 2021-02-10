using System.ComponentModel;
using System.Collections.Generic;

namespace WebApplication.Models.Calendar
{
    public class CalendarEventYearViewModel
    {
        [DisplayName("Год")]
        public int Year { get; set;  }
        
        [DisplayName("Выбор года")]
        public List<int> Years { get; set;  }
    }
}
