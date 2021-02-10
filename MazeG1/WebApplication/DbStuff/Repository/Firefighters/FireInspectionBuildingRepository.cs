using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.DbStuff.Model.Firefighters;
using WebApplication.DbStuff.Repository.IRepository.IFirefighters;
using WebApplication.Service;

namespace WebApplication.DbStuff.Repository.Firefighters
{
    public class FireInspectionBuildingRepository : BaseRepository<FireInspectionBuilding>, IFireInspectionBuildingRepository
    {
        public FireInspectionBuildingRepository(WebContext webContext) : base(webContext) { }

        public IQueryable<FireInspectionBuilding> GetByDateRange(DateTime from, DateTime to)
        {
            return _dbSet.Where(x => x.DateInspection > from && x.DateInspection < to);
        }

        public IQueryable<FireInspectionBuilding> GetByYear(int fireInspectionBuildingYear)
        {
            return _dbSet.Where(x => x.DateInspection.Year == fireInspectionBuildingYear);
        }

        public IQueryable<int> GetUniqInspectionYears()
        {
            return _dbSet.Select(x => x.DateInspection.Year).Distinct();
        }
    }
}
