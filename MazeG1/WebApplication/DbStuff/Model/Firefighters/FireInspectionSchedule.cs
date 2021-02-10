using System;
using System.ComponentModel;
using WebApplication.Models.Firefighters;

namespace WebApplication.DbStuff.Model.Firefighters
{
    public class FireInspectionSchedule : BaseModel
    {
        public long BuildingAdressId { get; set; }

        /// <summary>
        /// Адрес здания
        /// </summary>
        public virtual Adress BuildingAdress { get; set; }

        /// <summary>
        /// Дата осмотра по графику
        /// </summary>
        public virtual DateTime DateInspectionSchedule { get; set; }

        /// <summary>
        /// Периодичность осмотра
        /// </summary>
        public virtual InspectionPeriodicity FireInspectionPeriodicity { get; set; }
    }
}
