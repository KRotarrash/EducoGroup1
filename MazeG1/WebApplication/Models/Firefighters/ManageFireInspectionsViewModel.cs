using System.ComponentModel;

namespace WebApplication.Models.Firefighters
{
    /// <summary>
    /// Информация об осмотре зданий и о графике осмотра зданий
    /// </summary>
    public class ManageFireInspectionsViewModel
    {
        [DisplayName("Информация об осмотре зданий")]
        public FireInspectionBuildingViewModels FireInspectionsBuilding { get; set; }

        [DisplayName("График осмотра зданий")]
        public FireInspectionScheduleViewModels FireInspectionsSchedule { get; set; }
        
        [DisplayName("Выбор года")]
        public FireInspectionYearViewModel FireInspectionYear { get; set;  }
    }
}
