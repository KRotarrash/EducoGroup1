using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class VacancyViewModel
    {
        public long Id { get; set; }

        public OrganizationPositionViewModel OrganizationPosition { get; set; }
        
        public UserViewModel User { get; set; }

        public List<OrganizationPositionCandidateViewModel> Candidates { get; set; }
    }
}
