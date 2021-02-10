using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;

namespace WebApplication.DbStuff.Repository
{
    public abstract class BaseRepository<DbModel> : IBaseRepository<DbModel> where DbModel : BaseModel
    {
        protected WebContext _webContext;
        protected DbSet<DbModel> _dbSet;

        public BaseRepository(WebContext webContext)
        {
            _webContext = webContext;
            _dbSet = _webContext.Set<DbModel>();
        }

        public DbModel Get(long id)
        {
            return _dbSet.SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<DbModel> GetAll()
        {
            return _dbSet;
        }

        public int Count()
        {
            return _dbSet.Count();
        }

        public virtual bool IsAny()
        {
            return _dbSet.Any();
        }

        public virtual void Save(DbModel model)
        {
            if (model.Id > 0)
            {
                DetachLocalIfExist(model.Id);
                if (_webContext.Entry(model).State == EntityState.Detached)
                {
                    _dbSet.Attach(model);
                }

                _webContext.Entry(model).State = EntityState.Modified;
                _webContext.SaveChanges();
                return;
            }

            _dbSet.Add(model);
            _webContext.SaveChanges();
        }

        public void Remove(long id)
        {
            Remove(Get(id));
        }

        public void Remove(DbModel model)
        {
            _dbSet.Remove(model);
            _webContext.SaveChanges();
        }

        private void DetachLocalIfExist(long entryId)
        {
            var local = _webContext.Set<DbModel>()
                .Local
                .FirstOrDefault(entry => entry.Id == entryId);
            if (local != null)
            {
                _webContext.Entry(local).State = EntityState.Detached;
            }
        }
    }
}
