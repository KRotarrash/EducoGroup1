using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApplication.Models.Firefighters
{
    // Создание/редактирование информации графика осмотра зданий
    public class FireInspectionScheduleAddOrEditViewModel
    {
        public FireInspectionScheduleAddOrEditViewModel()
        {
            DateInspectionSchedule = DateTime.Now;
        }

        public long Id { get; set; }

        /// <summary>
        /// Список адресов
        /// </summary>
        [DisplayName("Адрес здания")]
        public List<AdressViewModel> BuildingAdresses { get; set; }

        /// <summary>
        /// Дата осмотра по графику
        /// </summary>
        /// 
        [Required(ErrorMessage = "Не указано Дата осмотра по графику!")]
        [DisplayName("Дата осмотра по графику")]
        public virtual DateTime DateInspectionSchedule { get; set; }

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
