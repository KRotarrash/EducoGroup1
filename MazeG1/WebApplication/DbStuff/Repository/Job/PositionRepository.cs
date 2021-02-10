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
    public class PositionRepository : BaseRepository<Position>, IPositionRepository
    {
        public PositionRepository(WebContext webContext) : base(webContext) { }

        public Position GetPositionByName(string name)
        {
            return _dbSet.FirstOrDefault(x => x.Name == name);
        }
    }
}
