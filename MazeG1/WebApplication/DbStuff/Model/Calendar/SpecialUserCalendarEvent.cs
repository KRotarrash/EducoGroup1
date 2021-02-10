namespace WebApplication.DbStuff.Model.Calendar
{
    public class SpecialUserCalendarEvent : BaseModel
    {
        public virtual SpecialUser User { get; set; }
        public virtual CalendarEvent CalendarEvent { get; set; }
    }
}
