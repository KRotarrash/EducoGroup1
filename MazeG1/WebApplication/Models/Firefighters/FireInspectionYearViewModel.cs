using System.ComponentModel;
using System.Collections.Generic;

namespace WebApplication.Models.Firefighters
{
    /// <summary>
    /// Выбор года для отображения информации об осмотре зданий по годам
    /// </summary>
    public class FireInspectionYearViewModel
    {
        [DisplayName("Год")]
        public int Year { get; set;  }
        
        [DisplayName("Выбор года")]
        public List<int> Years { get; set;  }
    }
}
