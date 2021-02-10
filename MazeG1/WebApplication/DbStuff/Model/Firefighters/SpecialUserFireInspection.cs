namespace WebApplication.DbStuff.Model.Firefighters
{
    public class SpecialUserFireInspection : BaseModel
    {
        public virtual SpecialUser User { get; set; }

        public virtual FireInspectionBuilding FireInspectionBuilding { get; set; }
    }
}
