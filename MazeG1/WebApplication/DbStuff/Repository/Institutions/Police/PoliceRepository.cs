using WebApplication.DbStuff.Institutions;
using WebApplication.DbStuff.Repository.IInstitutions.IPolice;

namespace WebApplication.DbStuff.Repository
{
    public class PoliceRepository : BaseRepository<Police>, IPoliceRepository
    {
        public PoliceRepository(WebContext webContext) : base(webContext) { }

    }
}
