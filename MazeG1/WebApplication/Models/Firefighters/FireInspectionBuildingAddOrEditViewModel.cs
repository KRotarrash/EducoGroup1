﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApplication.Models.Firefighters
{
    /// <summary>
    /// Создание/редактирование информации об осмотре зданий
    /// </summary>
    public class FireInspectionBuildingAddOrEditViewModel
    {
        public FireInspectionBuildingAddOrEditViewModel()
        {
            DateInspection = DateTime.Now;
        }

        public long Id { get; set; }

        /// <summary>
        /// Адреса зданий
        /// </summary>
        [DisplayName("Адрес здания")]
        public virtual List<AdressViewModel> BuildingAdresses { get; set; }

        /// <summary>
        /// Оценка безопасности здания
        /// </summary>
        public long BuildingTypeSafetyAssessmentId { get; set; }
        public string NameOfTypeSafetyAssessment { get; set; }

        [DisplayName("Оценка безопасности здания")]
        public List<BuildingTypeSafetyAssessmentViewModel> BuildingTypeSafetyAssessments { get; set; }

        /// <summary>
        /// Дата осмотра
        /// </summary>
        /// 
        [Required(ErrorMessage = "Не указано Дата осмотра!")]
        [DisplayName("Дата осмотра")]
        public DateTime DateInspection { get; set; }

        /// <summary>
        /// Время осмотра
        /// </summary>
        [Required(ErrorMessage = "Не указано Время осмотра!")]
        [DisplayName("Время осмотра")]
        public DateTime TimeInspection { get; set; }

        /// <summary>
        /// Кто проводил осмотр
        /// </summary>
        [DisplayName("Кто проводил осмотр")]
        public long OwnerId { get; set; }

        public long BuildingAdressId { get; set; }

    }
}
