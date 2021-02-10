using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Firefighters
{
    /// <summary>
    /// График с информацией осмотра зданий
    /// </summary>
    public class FireInspectionBuildingChartDataViewModel
    {
        /// <summary>
        /// Количество осмотров зданий
        /// </summary>
        public int CountInspections { get; set; }

        /// <summary>
        /// Количество осмотров зданий в шаге по оси Y
        /// </summary>
        public int CountInspectionsStep { get; set; }

        /// <summary>
        /// Количество осмотров зданий в месяц
        /// </summary>
        public List<int> CountInspectionsByMonth { get; set; }
    }
}
