using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model.Job;
using WebApplication.DbStuff.Repository.IRepository.IJob;
using Position = WebApplication.DbStuff.Model.Job.Position;

namespace WebApplication.DbStuff.Repository.Job
{
    public class OfficeRepository : BaseRepository<Office>, IOfficeRepository
    {
        public OfficeRepository(WebContext webContext) : base(webContext) { }

        public Office Get(string name)
        {
            return _dbSet.SingleOrDefault(x => x.Name == name);
        }

        public List<Office> GetFreeOffices()
        {
            return _dbSet.Where(x => x.Organization.Name == HostSeed.OrganizationDefault).ToList();
        }

        public Office GetMainOffice(long organizationId)
        {
            return _dbSet.SingleOrDefault(x => x.Organization.Id == organizationId && x.OfficeType == OfficeType.Main);
        }

    }
}
