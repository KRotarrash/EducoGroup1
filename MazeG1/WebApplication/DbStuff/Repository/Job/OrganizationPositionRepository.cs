using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Model.Job;
using WebApplication.DbStuff.Repository.IRepository.IJob;

namespace WebApplication.DbStuff.Repository.Job
{
    public class OrganizationPositionRepository : BaseRepository<OrganizationPosition>,
        IOrganizationPositionRepository
    {
        public OrganizationPositionRepository(WebContext webContext) : base(webContext) { }

        public IQueryable<OrganizationPosition> GetAvailableVacancy()
        {
            return _dbSet.Where(x => !x.Workers.Any());
        }

        public OrganizationPosition GetByOrganizationAndPostionIds(long organizationId, long positionId)
        {
            return _dbSet.SingleOrDefault(x => x.Organization.Id == organizationId
                && x.Position.Id == positionId);
        }

        public OrganizationPosition GetByPositionName(string name)
        {
            return _dbSet.SingleOrDefault(x => x.Position.Name == name);
        }

        public OrganizationPosition GetOrganizationPositionDefault(Organization organization, Position position)
        {
            return _dbSet.FirstOrDefault(x => x.Organization.Name == organization.Name &&
                 x.Position.Name == position.Name);
        }

        public OrganizationPosition GetOrganizationPositionDefault(string organizationName, string positionName)
        {
            return _dbSet.FirstOrDefault(x => x.Organization.Name == organizationName &&
                 x.Position.Name == positionName);
        }

        public bool IsPositionNameInOrganizationUnique(long organizationId, string positionName)
        {
            return !_dbSet.Any(x => 
                x.Organization.Id == organizationId 
                && x.Position.Name.Trim().ToLower() == positionName.Trim().ToLower());
        }
    }
}
