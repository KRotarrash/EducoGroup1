using System.Collections.Generic;

namespace WebApplication.Models
{
    public class OrganizationPositionViewModel
    {
        public long Id { get; set; }
        public OrganizationViewModel Organization { get; set; }
        public PositionViewModel Position { get; set; }

        public List<OrganizationPositionCandidateViewModel> Candidates { get; set; }
    }
}