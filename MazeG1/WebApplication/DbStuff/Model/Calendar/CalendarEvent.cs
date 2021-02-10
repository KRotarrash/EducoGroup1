using System;
using System.Collections.Generic;

namespace WebApplication.DbStuff.Model.Calendar
{
    public class CalendarEvent : BaseModel
    {
        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime DateStartEvent { get; set; }

        public virtual DateTime DateFinishEvent { get; set; }

        public virtual CalendarTypeEvent CalendarTypeEvent { get; set; }

        public virtual List<SpecialUserCalendarEvent> SeenCalendarEventByUsers { get; set; }
    }
}
