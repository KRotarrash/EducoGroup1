using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApplication.Models.Firefighters
{
    // График осмотра зданий
    public class FireInspectionScheduleViewModel
    {
        public FireInspectionScheduleViewModel()
        {
            DateInspectionSchedule = DateTime.Now;
        }

        public long Id { get; set; }

        /// <summary>
        /// Адрес здания
        /// </summary>
        [DisplayName("Адрес здания")]
        public virtual AdressViewModel BuildingAdress { get; set; }

        /// <summary>
        /// Дата осмотра по графику
        /// </summary>
        /// 
        [Required(ErrorMessage = "Не указано Дата осмотра по графику!")]
        [DisplayName("Дата осмотра по графику")]
        public virtual DateTime DateInspectionSchedule { get; set; }

        /// <summary>
        /// Дата осмотра по графику с установленным форматом
        /// </summary>
        public string FormatDateInspectionSchedule { get; set; }

        /// <summary>
        /// Время осмотра по графику
        /// </summary>
        [Required(ErrorMessage = "Не указано Время осмотра по графику!")]
        [DisplayName("Время осмотра")]
        public DateTime TimeInspectionSchedule { get; set; }

        [DisplayName("Периодичность осмотра")]
        public virtual InspectionPeriodicity FireInspectionPeriodicity { get; set; }

        public long BuildingAdressId { get; set; }
    }
}
