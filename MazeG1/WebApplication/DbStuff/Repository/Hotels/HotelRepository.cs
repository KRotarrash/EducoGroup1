using System.Collections.Generic;
using System.Linq;
using WebApplication.DbStuff.Model.Hotels;
using WebApplication.DbStuff.Repository.IRepository.IHotels;

namespace WebApplication.DbStuff.Repository.Hotels
{
    public class HotelRepository : BaseRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(WebContext webContext) : base(webContext) { }

        public Hotel GetHotelByName(string name)
        {
            return _dbSet.FirstOrDefault(x => x.Name == name);
        }
    }
}
