using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Job
{
    public class OrganizationOfficesManagerViewModel
    {
        public long Id { get; set; }        
        [DisplayName("Организация:")]
        public string Name { get; set; }
        public OfficeViewModel MainOffice { get; set; }
        public List<OfficeViewModel> Offices { get; set; }
        public List<OfficeViewModel> FreeOffices { get; set; }
        public long AddedOfficeId { get; set; }
    }
}
