using WebApplication.DbStuff.Model.Hospital;

namespace WebApplication.DbStuff.Repository
{
    public class HospitalRepository : BaseRepository<Hospital>, IHospitalRepository
    {
        public HospitalRepository(WebContext webContext) : base(webContext) { }

    }
}
