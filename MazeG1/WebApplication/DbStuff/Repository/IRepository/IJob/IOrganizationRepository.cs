using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model.Job;

namespace WebApplication.DbStuff.Repository.IRepository.IJob
{
    public interface IOrganizationRepository : IBaseRepository<Organization>
    {
        Organization GetOrganizationByName(string name);
        bool OrganizationNameIsUniq(string organizationName);       
    }
}
