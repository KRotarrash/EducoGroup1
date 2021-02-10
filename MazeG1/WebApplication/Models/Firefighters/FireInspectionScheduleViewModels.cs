using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApplication.Models.Firefighters
{
    public class FireInspectionScheduleViewModels
    {
        // График осмотра зданий (таблица)
        public List<FireInspectionScheduleViewModel> FireInspectionsSchedule { get; set; }
        public PaginatorInfoViewModel PaginatorInfo { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
