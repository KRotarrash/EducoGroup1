using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class JobViewModel
    {
        public long Id { get; set; }
        public OrganizationViewModel Organization { get; set; }
        public PositionViewModel Position { get; set; }
        public List<JobViewModel> JobViewModels { get; set; }
        public List<OrganizationViewModel> Organizations { get; set; }

        public UserViewModel User { get; set; } 
    }
}
