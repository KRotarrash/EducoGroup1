using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Repository.IRepository.IJob;
using WebApplication.DbStuff.Repository.Job;

namespace WebApplication.DbStuff.Repository
{
    public class MarriageRepository : BaseRepository<Marriage>, IMarriageRepository
    {
        public MarriageRepository(WebContext webContext) : base(webContext) { }

        public Marriage GetMarriage(long partnerId1, long partnerId2)
        {
            return _dbSet.SingleOrDefault(x => (x.Husband.Id == partnerId1 && x.Wife.Id == partnerId2) || (x.Husband.Id == partnerId2 && x.Wife.Id == partnerId1) && x.DateFinishMarriage == null);
        }
    }
}
