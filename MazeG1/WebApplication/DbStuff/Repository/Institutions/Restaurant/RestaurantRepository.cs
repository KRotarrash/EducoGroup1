using WebApplication.DbStuff.Institutions;

namespace WebApplication.DbStuff.Repository
{
    public class RestaurantRepository : BaseRepository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(WebContext webContext) : base(webContext) { }

    }
}
