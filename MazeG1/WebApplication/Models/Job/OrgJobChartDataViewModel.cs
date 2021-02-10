using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Users
{
    public class OrgJobChartDataViewModel
    {
        public List<string> OrganizationNames { get; set; }
        public List<int> OccupiedJob { get; set; }
        public List<int> FreeJob { get; set; }
    }
}
