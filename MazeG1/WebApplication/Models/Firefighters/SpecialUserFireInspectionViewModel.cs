namespace WebApplication.Models.Firefighters
{
    /// <summary>
    /// Кто проводил осмотр
    /// </summary>
    public class SpecialUserFireInspectionViewModel
    {
        public long Id { get; set; }
        public virtual UserViewModel User { get; set; }
    }
}
