using System.Collections.Generic;

namespace WebApplication.DbStuff.Model.Calendar
{
    public class CalendarTypeEvent : BaseModel
    {
        public virtual string NameOfTypeEvent { get; set; }

        public virtual List<CalendarEvent> CalendarEvents { get; set; }
    }
}
