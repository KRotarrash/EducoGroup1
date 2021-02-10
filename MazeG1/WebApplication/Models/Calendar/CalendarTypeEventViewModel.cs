using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.Calendar
{
    public class CalendarTypeEventViewModel
    {
        /// <summary>
        /// Идентификатор события
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Наименование типа события 
        /// </summary>
        [Required(ErrorMessage = "Не указано Наименование типа события!")]
        [DisplayName("Наименование типа события")]
        public virtual string NameOfTypeEvent { get; set; }
    }
}
