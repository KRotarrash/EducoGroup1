using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Repository.IRepository.IJob;
using WebApplication.DbStuff.Repository.Job;

namespace WebApplication.DbStuff.Repository
{
    public class SpecialUserRepository : BaseRepository<SpecialUser>, ISpecialUserRepository
    {
        private IOrganizationPositionRepository _organizationPositionRepository;
        public SpecialUserRepository(WebContext webContext,
            IOrganizationPositionRepository organizationPositionRepository) : base(webContext)
        {
            _organizationPositionRepository = organizationPositionRepository;
        }

        public override void Save(SpecialUser user)
        {
            if (user.CurrentWork == null)
            {
                user.CurrentWork =
                    _organizationPositionRepository.GetOrganizationPositionDefault(HostSeed.OrganizationDefault,
                       HostSeed.PositionDefault);
            }
            base.Save(user);
        }

        public SpecialUser GetMaria()
        {
            return _dbSet.SingleOrDefault(x => x.Name == "Maria");
        }

        public SpecialUser GetUserByName(string name)
        {
            return _dbSet.FirstOrDefault(x => x.Name == name);
        }

        public SpecialUser GetUserByNameAndPass(string name, string password)
        {
            return _dbSet.FirstOrDefault(x => x.Name == name && x.Password == password);
        }

        public SpecialUser GetUserByNameWithEmptyPassword(string name)
        {
            return _dbSet.FirstOrDefault(x => x.Name == name && x.Password == null);
        }

        public List<long> GetUserOrganizationPositionIds()
        {
            var organizationPositionId = _dbSet
                .Where(x => x.CurrentWork != null
                    || x.CurrentWork.Position.Name == HostSeed.PositionDefault)
                .Select(x => x.CurrentWork.Id)
                .ToList();
            return organizationPositionId;
        }

        public SpecialUser GetUserOnOrganizationPosition(long organizationPositionId)
        {
            return _dbSet.FirstOrDefault(x => x.CurrentWork.Id == organizationPositionId);
        }

        public List<long> GetUserOrganizationPositionIdsByOrganization(long organizationId)
        {
            var organizationPositionId = _dbSet
                .Where(x => x.CurrentWork.Organization.Id == organizationId)
                .Select(x => x.CurrentWork.Id)
                .Distinct()
                .ToList();
            return organizationPositionId;
        }
        public IEnumerable<long> GetUserIdsWhoHelperForOtherHotels(long hotelId)
        {
            return _dbSet.Where(x => x.HotelUserIsHelper != null && x.HotelUserIsHelper.Id != hotelId)
                .Select(x => x.Id)
                .Distinct();
        }

        public bool IsUserIsHelperForHotel(long userId, long hotelId)
        {
            return _dbSet.Any(x => x.Id == userId && x.HotelUserIsHelper != null && x.HotelUserIsHelper.Id == hotelId);
        }

        public SpecialUser GetMayor()
        {
            return _dbSet.SingleOrDefault(x => 
                x.CurrentWork.Position.Name == HostSeed.MayorPositionDefault);
        }

        public SpecialUser GetPartnerByUserId(long userId)
        {
            return _dbSet.FirstOrDefault(x => x.PartnerId == userId);
        }

        public List<SpecialUser> GetUsersToMarriage(long userId)
        {
            return _dbSet.Where(x => x.Id != userId && x.Age >= 18 && x.PartnerId == null)
                .ToList();
        }

        public SpecialUser GetFirefighter()
        {
            return _dbSet.SingleOrDefault(x =>
                x.CurrentWork.Position.Name == HostSeed.FirefightersPositionDefault);
        }
    }
}
