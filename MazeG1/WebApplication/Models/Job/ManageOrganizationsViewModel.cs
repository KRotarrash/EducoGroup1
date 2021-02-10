using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class ManageOrganizationsViewModel
    {
        public List<OrganizationViewModel> Organizations { get; set; }
        
        public PaginatorInfoViewModel PaginatorInfo { get; set; }

        public SortViewModel SortViewModel { get; set; }
    }
}
