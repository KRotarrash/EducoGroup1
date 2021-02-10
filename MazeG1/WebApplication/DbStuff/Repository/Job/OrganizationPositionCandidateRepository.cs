using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model.Job;
using WebApplication.DbStuff.Repository.IRepository.IJob;

namespace WebApplication.DbStuff.Repository.Job
{
    public class OrganizationPositionCandidateRepository : BaseRepository<OrganizationPositionCandidate>,
        IOrganizationPositionCandidateRepository
    {
        public OrganizationPositionCandidateRepository(WebContext webContext) : base(webContext) { }

        public IEnumerable<OrganizationPositionCandidate> GetCandidatesForJob(long jobId)
        {
            return _dbSet.Where(x => x.OrganizationPosition.Id == jobId).ToList();
        }
    }
}
