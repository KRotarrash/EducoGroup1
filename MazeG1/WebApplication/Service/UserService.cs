using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using WebApplication.DbStuff;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Repository;
using WebApplication.DbStuff.Repository.IRepository.IJob;

namespace WebApplication.Service
{
    public class UserService : IUserService
    {
        private ISpecialUserRepository _specialUserRepository;
        private IOrganizationRepository _organizationRepository;
        private IHttpContextAccessor _httpContextAccessor;
        private const string administratorName = "Администратор";


        public UserService(ISpecialUserRepository specialUserRepository,
            IHttpContextAccessor httpContextAccessor, 
            IOrganizationRepository organizationRepository)
        {
            _specialUserRepository = specialUserRepository;
            _httpContextAccessor = httpContextAccessor;
            _organizationRepository = organizationRepository;
        }

        public SpecialUser GetCurrentUser()
        {
            var idStr = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(x => x.Type == "Id")?.Value;
            if (string.IsNullOrEmpty(idStr))
            {
                return null;
            }
            var id = int.Parse(idStr);
            return _specialUserRepository.Get(id);
        }
        public bool IsMayor()
        {
            var user = GetCurrentUser();
            return user?.CurrentWork.Position.Name == HostSeed.MayorPositionDefault || IsAdmin();
        }
        public bool IsPoliceman()
        {
            var user = GetCurrentUser();
            return user?.CurrentWork.Organization.Name == HostSeed.PoliceNameDefault || IsAdmin();
        }
        public bool IsBlocked(string name)
        {
            var user = _specialUserRepository.GetUserByName(name);
            return user != null && (DateTime.Now < user.EndBlocked);
        }
        public bool IsBlocked(long id)
        {
            var user = _specialUserRepository.Get(id);
            return user != null && (DateTime.Now < user.EndBlocked);
        }
        public bool IsOwnerOrganization()
        {
            var user = GetCurrentUser();

            if (user == null)
            {
                return false;
            }

            var organizations = _organizationRepository
                    .GetAll()
                    .Where(x => x.Owner == user)
                    .ToList();

            return organizations.Any();
        }
        public bool IsAdministratorOrganization(long id)
        {
            var user = GetCurrentUser();

            if (user != null && user.CurrentWork.Position.Name == administratorName)
            {
                var organization = _organizationRepository.Get(id);

                return organization.OrganizationPositions.Contains(user.CurrentWork);
            }

            return false;
        }

        public bool IsDoctor()
        {
            var user = GetCurrentUser();
            if (user == null)
                return false;

            return user.CurrentWork.Organization.Name == HostSeed.HospitalNameDefault || IsAdmin();
        }

        public bool IsAdmin()
        {
            var user = GetCurrentUser();
            return user?.WebRole == WebRole.Admin;
        }

        public bool IsFirefighter()
        {
            var user = GetCurrentUser();
            return user?.CurrentWork.Organization.Name == HostSeed.FirefightersOrganizationDefault;
        }
    }
}
