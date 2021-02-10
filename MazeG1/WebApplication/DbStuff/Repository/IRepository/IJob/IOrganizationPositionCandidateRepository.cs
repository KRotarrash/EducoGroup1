using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model.Job;

namespace WebApplication.DbStuff.Repository.IRepository.IJob
{
    public interface IOrganizationPositionCandidateRepository : IBaseRepository<OrganizationPositionCandidate>
    {
        IEnumerable<OrganizationPositionCandidate> GetCandidatesForJob(long jobId);
    }
}
