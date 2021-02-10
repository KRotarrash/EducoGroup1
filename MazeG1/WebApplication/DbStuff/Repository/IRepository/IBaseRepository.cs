using System.Collections.Generic;
using System.Linq;
using WebApplication.DbStuff.Model;

namespace WebApplication.DbStuff.Repository
{
    public interface IBaseRepository<DbModel> where DbModel : BaseModel
    {
        int Count();
        DbModel Get(long id);
        IQueryable<DbModel> GetAll();
        bool IsAny();
        void Remove(DbModel model);
        void Remove(long id);
        void Save(DbModel model);
    }
}