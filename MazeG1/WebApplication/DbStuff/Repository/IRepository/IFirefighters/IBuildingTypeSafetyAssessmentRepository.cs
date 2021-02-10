using WebApplication.DbStuff.Model.Firefighters;

namespace WebApplication.DbStuff.Repository.IRepository.IFirefighters
{
    public interface IBuildingTypeSafetyAssessmentRepository : IBaseRepository<BuildingTypeSafetyAssessment>
    {
        BuildingTypeSafetyAssessment GetById(int id);
    }
}
