using System;

namespace WebApplication.DbStuff.Model.Firefighters
{
    public class FireInspectionBuilding : BaseModel
    {
        /// <summary>
        /// Адрес здания
        /// </summary>
        public virtual Adress BuildingAdress { get; set; }

        /// <summary>
        /// Дата осмотра
        /// </summary>
        public virtual DateTime DateInspection { get; set; }

        /// <summary>
        /// Оценка безопасности здания
        /// </summary>
        public virtual BuildingTypeSafetyAssessment BuildingTypeSafetyAssessment { get; set; }

        /// <summary>
        /// Идентификатор пользователя, кто проводил осмотр
        /// </summary>
        public long SpecialUserFireInspectionId { get; set; }

        /// <summary>
        /// Кто проводил осмотр
        /// </summary>
        public virtual SpecialUserFireInspection PerformedFireInspectionBuildingByUser { get; set; }
    }
}
