using WebApplication.DbStuff.Model;

namespace WebApplication.Service
{
    public interface IUserService
    {
        SpecialUser GetCurrentUser();
        bool IsAdministratorOrganization(long id);
        bool IsMayor();
        bool IsOwnerOrganization();
        bool IsBlocked(string name);
        bool IsBlocked(long id);
        bool IsPoliceman();
        bool IsDoctor();

        bool IsAdmin();
        bool IsFirefighter();
    }
}