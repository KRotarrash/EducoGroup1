using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model.Job;

namespace WebApplication.DbStuff.Repository.IRepository.IJob
{
    public interface IOrganizationPositionRepository : IBaseRepository<OrganizationPosition>
    {
        OrganizationPosition GetByOrganizationAndPostionIds(long organizationId, long positionId);
        OrganizationPosition GetByPositionName(string name);
        OrganizationPosition GetOrganizationPositionDefault(Organization organization, Position position);
        OrganizationPosition GetOrganizationPositionDefault(string organizationName, string positionName);
        bool IsPositionNameInOrganizationUnique(long organizationId, string positionName);
        IQueryable<OrganizationPosition> GetAvailableVacancy();
    }
}
