using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApplication.Models.Calendar
{
    public class CalendarEventViewModel
    {
        public CalendarEventViewModel()
        {
            DateEvent = DateTime.Now;
            MinDateEvent = DateEvent.ToString("yyyy-MM-dd");
        }

        public long Id { get; set; }

        /// <summary>
        /// Название события
        /// </summary>
        [Required(ErrorMessage = "Не указано Название события!")]
        [DisplayName("Название события")]
        public string Title { get; set; }

        /// <summary>
        /// Описание события
        /// </summary>
        [Required(ErrorMessage = "Не указано Описание события!")]
        [DisplayName("Описание события")]
        public string Description { get; set; }

        /// <summary>
        /// Тип события
        /// </summary>
        [DisplayName("Тип события")]
        public CalendarTypeEventViewModel CalendarTypeEvent { get; set; }

        [DisplayName("Тип события")]
        public List<CalendarTypeEventViewModel> CalendarTypeEvents { get; set; }

        /// <summary>
        /// Дата события
        /// </summary>
        [Required(ErrorMessage = "Не указано Дата события!")]
        [DisplayName("Дата события")]
        public DateTime DateEvent { get; set; }

        /// <summary>
        /// Минимальная дата для события
        /// </summary>
        public string MinDateEvent { get; set; }
        
        /// <summary>
        /// Дата события с устанновленным форматом
        /// </summary>
        public string FormatDateEvent { get; set; }

        /// <summary>
        /// Время события
        /// </summary>
        [Required(ErrorMessage = "Не указано Время события!")]
        [DisplayName("Время события")]
        // public TimeSpan Time { get; set; }
        public DateTime TimeEvent { get; set; }
    }
}
