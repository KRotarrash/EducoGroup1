using System.Collections.Generic;
using WebApplication.DbStuff.Model;

namespace WebApplication.Models.Firefighters
{
    public class FireInspectionBuildingViewModels
    {
        /// <summary>
        /// Информация об осмотре зданий (таблица)
        /// </summary>
        public List<FireInspectionBuildingViewModel> FireInspectionsBuilding { get; set; }
        public SpecialUser CurrentUser { get; set; }
        public PaginatorInfoViewModel PaginatorInfo { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
