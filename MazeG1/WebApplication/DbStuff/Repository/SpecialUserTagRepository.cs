using WebApplication.DbStuff.Model;

namespace WebApplication.DbStuff.Repository
{
    public class SpecialUserTagRepository : BaseRepository<SpecialUserTag>, ISpecialUserTagRepository
    {
        public SpecialUserTagRepository(WebContext webContext) : base(webContext) { }
    }
}
