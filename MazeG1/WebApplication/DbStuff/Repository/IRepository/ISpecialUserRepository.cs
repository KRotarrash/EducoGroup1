using System.Collections.Generic;
using WebApplication.DbStuff.Model;

namespace WebApplication.DbStuff.Repository
{
    public interface ISpecialUserRepository : IBaseRepository<SpecialUser>
    {
        SpecialUser GetMaria();
        SpecialUser GetUserByName(string name);
        SpecialUser GetUserByNameAndPass(string name, string password);
        SpecialUser GetUserByNameWithEmptyPassword(string name);
        List<long> GetUserOrganizationPositionIds();
        SpecialUser GetUserOnOrganizationPosition(long organizationPositionId);
        List<long> GetUserOrganizationPositionIdsByOrganization(long organizationId);
        IEnumerable<long> GetUserIdsWhoHelperForOtherHotels(long hotelId);
        bool IsUserIsHelperForHotel(long userId, long hotelId);
        SpecialUser GetMayor();
        SpecialUser GetPartnerByUserId(long userId);

        List<SpecialUser> GetUsersToMarriage(long userId);
        SpecialUser GetFirefighter();
    }
}