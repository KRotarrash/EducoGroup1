using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Institutions;
using WebApplication.DbStuff.Model.Job;
using WebApplication.DbStuff.Repository.IRepository.IJob;

namespace WebApplication.DbStuff.Repository.Job
{
    public class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(WebContext webContext) : base(webContext) { }

        public Organization GetOrganizationByName(string name)
        {
            return _dbSet.FirstOrDefault(x => x.Name == name);
        }

        public bool OrganizationNameIsUniq(string organizationName)
        {
            return _dbSet.All(x => x.Name.ToLower().Trim() != organizationName.ToLower().Trim());
        }
    }
}
