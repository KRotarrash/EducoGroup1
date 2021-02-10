using System.Linq;
using WebApplication.DbStuff.Model.Firefighters;
using WebApplication.DbStuff.Repository.IRepository.IFirefighters;

namespace WebApplication.DbStuff.Repository.Firefighters
{
    public class BuildingTypeSafetyAssessmentRepository : BaseRepository<BuildingTypeSafetyAssessment>, IBuildingTypeSafetyAssessmentRepository
    {
        public BuildingTypeSafetyAssessmentRepository(WebContext webContext) : base(webContext) { }

        public BuildingTypeSafetyAssessment GetById(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }
    }
}
