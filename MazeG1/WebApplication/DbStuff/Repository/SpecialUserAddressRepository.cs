using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.DbStuff.Model;

namespace WebApplication.DbStuff.Repository
{
    public class SpecialUserAddressRepository : BaseRepository<SpecialUserAddress>, ISpecialUserAddressRepository
    {
        public SpecialUserAddressRepository(WebContext webContext) : base(webContext) { }

        public int GetSpecialUserCountForAddress(Adress address)
        {
            return _dbSet.Where(a => a.Adress == address).Count();
        }
    }
}
