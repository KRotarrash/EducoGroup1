using System.Linq;
using WebApplication.DbStuff.Model.Firefighters;
using WebApplication.DbStuff.Repository.IRepository.IFirefighters;

namespace WebApplication.DbStuff.Repository.Firefighters
{
    public class SpecialUserFireInspectionRepository : BaseRepository<SpecialUserFireInspection>, ISpecialUserFireInspectionRepository
    {
        public SpecialUserFireInspectionRepository(WebContext webContext) : base(webContext) { }

        public SpecialUserFireInspection GetByUserId(long userId)
        {
            return _dbSet.FirstOrDefault(x => x.User.Id == userId);
        }
    }
}
