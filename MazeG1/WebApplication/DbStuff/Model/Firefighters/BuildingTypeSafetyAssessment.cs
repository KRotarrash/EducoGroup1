using System.Collections.Generic;

namespace WebApplication.DbStuff.Model.Firefighters
{
    public class BuildingTypeSafetyAssessment : BaseModel
    {
        public virtual string NameOfTypeSafetyAssessment { get; set; }

        public virtual List<FireInspectionBuilding> FireInspectionsBuilding { get; set; }
    }
}
