using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model.Job;
using WebApplication.Models.Job;

namespace WebApplication.Models
{
    public class OrganizationViewModel
    {
        public long Id { get; set; }
        public long OwnerId { get; set; }
        [DisplayName("Организация:")]
        public string Name { get; set; }        
        public int SalaryDate { get; set; }
        public long JobId { get; set; }
        public List<OrganizationPositionViewModel> Positions { get; set; }
        public OrganizationType OrganizationType { get; set; }
        public DateTime StartWork { get; set; }
        public DateTime EndWork { get; set; }
        public UserViewModel Owner { get; set; }
        public List<UserViewModel> Users { get; set; }
        public OfficeViewModel MainOffice { get; set; }
        public List<OfficeViewModel> FreeOffices { get; set; }
    }
}
