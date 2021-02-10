using WebApplication.DbStuff.Model;

namespace WebApplication.DbStuff.Repository
{
    public interface ICalcHistoryRepository : IBaseRepository<CalcHistory>
    {
        void Clear();
    }
}