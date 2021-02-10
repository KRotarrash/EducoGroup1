using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;

namespace WebApplication.Models
{
    public class ManageCandidateViewModel
    {
        public VacancyViewModel Vacancy { get; set; }

        public List<OrganizationPositionCandidateViewModel> Candidates { get; set; }

        public PaginatorInfoViewModel PaginatorInfo { get; set; }

        public SortViewModel SortViewModel { get; set; }
    }
}
