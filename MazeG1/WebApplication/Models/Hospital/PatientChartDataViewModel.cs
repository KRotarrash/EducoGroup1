using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class PatientChartDataViewModel
    {
        public List<string> Months { get; set; }

        public List<int> CountDetail { get; set; }
    }
}
