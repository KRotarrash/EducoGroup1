using System;
using System.Linq;
using System.Collections.Generic;
using WebApplication.DbStuff.Model.Firefighters;

namespace WebApplication.DbStuff.Repository.IRepository.IFirefighters
{
    public interface IFireInspectionBuildingRepository : IBaseRepository<FireInspectionBuilding>
    {
        IQueryable<FireInspectionBuilding> GetByDateRange(DateTime from, DateTime to);

        IQueryable<FireInspectionBuilding> GetByYear(int fireInspectionBuildingYear);

        IQueryable<int> GetUniqInspectionYears();
    }
}
