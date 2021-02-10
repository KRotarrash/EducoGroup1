using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;

namespace WebApplication.DbStuff.Repository
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(WebContext webContext) : base(webContext) { }

        Tag ITagRepository.GetByName(string name)
        {
            return _dbSet.SingleOrDefault(x => x.Name == name);
        }
    }
}
