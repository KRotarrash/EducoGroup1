using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;

namespace WebApplication.DbStuff.Repository
{
    public class CalcHistoryRepository : BaseRepository<CalcHistory>, ICalcHistoryRepository
    {
        public CalcHistoryRepository(WebContext webContext) : base(webContext) { }

        public void Clear()
        {
            _dbSet.RemoveRange(_dbSet);
            _webContext.SaveChanges();
        }
    }
}
