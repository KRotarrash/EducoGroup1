using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Repository;
using WebApplication.DbStuff.Repository.IRepository.IJob;

namespace WebApplication.Service
{
    public class OrganizationService : IOrganizationService
    {
        private IOrganizationRepository _organizationRepository;

        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public bool IsOrganizationWorksTimes(long id)
        {
            var organization = _organizationRepository.Get(id);

            var startWork = organization.StartWork.TimeOfDay;
            var endWork = organization.EndWork.TimeOfDay;
            var now = DateTime.Now.TimeOfDay;

            if (startWork == endWork)
            {
                return true;
            }
            if (startWork < endWork)
            {
                return startWork < now && now < endWork;
            }
            else
            {
                if (startWork > now && now < endWork)
                {
                    return true;
                }

                return startWork < now;
            }
        }
    }
}
