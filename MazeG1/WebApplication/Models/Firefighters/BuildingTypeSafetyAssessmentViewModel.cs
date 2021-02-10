using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.Firefighters
{
    /// <summary>
    /// Типы оценки безопасности здания
    /// </summary>
    public class BuildingTypeSafetyAssessmentViewModel
    {
        /// <summary>
        /// Идентификатор оценки безопасности здания
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Наименование типа оценки безопасности здания
        /// </summary>
        [Required(ErrorMessage = "Не указано Наименование типа оценки безопасности здания!")]
        [DisplayName("Наименование типа оценки безопасности здания")]
        public virtual string NameOfTypeSafetyAssessment { get; set; }
    }
}
