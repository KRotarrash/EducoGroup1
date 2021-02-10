using WebApplication.DbStuff.Model.Hotels;

namespace WebApplication.DbStuff.Repository.IRepository.IHotels
{
    public interface IHotelRepository : IBaseRepository<Hotel>
    {
        Hotel GetHotelByName(string name);
    }
}
