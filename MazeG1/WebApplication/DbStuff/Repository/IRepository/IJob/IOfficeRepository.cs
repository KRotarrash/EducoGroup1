using System.Collections.Generic;
using WebApplication.DbStuff.Model.Job;

namespace WebApplication.DbStuff.Repository.IRepository.IJob
{
    public interface IOfficeRepository : IBaseRepository<Office>
    {
        Office Get(string name);
        public List<Office> GetFreeOffices();
        Office GetMainOffice(long organizationId);
    }
}