namespace WebApplication.Models
{
    public class OrganizationPositionCandidateViewModel
    {
        public long Id { get; set; }

        public OrganizationPositionViewModel OrganizationPosition { get; set; }

        public UserViewModel User { get; set; }
    }
}