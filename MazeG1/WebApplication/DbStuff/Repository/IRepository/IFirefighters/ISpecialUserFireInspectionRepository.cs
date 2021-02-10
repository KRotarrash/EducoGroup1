using WebApplication.DbStuff.Model.Firefighters;

namespace WebApplication.DbStuff.Repository.IRepository.IFirefighters
{
    public interface ISpecialUserFireInspectionRepository : IBaseRepository<SpecialUserFireInspection>
    {
        SpecialUserFireInspection GetByUserId(long userId);
    }
}
