using System.Collections.Generic;
using WebApplication.DbStuff.Model;

namespace WebApplication.DbStuff.Repository
{
    public interface IMarriageRepository : IBaseRepository<Marriage>
    {
        Marriage GetMarriage(long partnerId1, long partnerId2);
    }
}