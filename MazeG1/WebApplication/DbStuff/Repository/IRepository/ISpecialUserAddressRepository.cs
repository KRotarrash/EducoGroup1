using WebApplication.DbStuff.Model;

namespace WebApplication.DbStuff.Repository
{
    public interface ISpecialUserAddressRepository : IBaseRepository<SpecialUserAddress>
    {
        int GetSpecialUserCountForAddress(Adress address);
    }
}