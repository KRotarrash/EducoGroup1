using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.DbStuff.Model.Firefighters;

namespace WebApplication.DbStuff.Repository.IRepository.IFirefighters
{
    public interface IFireInspectionScheduleRepository : IBaseRepository<FireInspectionSchedule>
    {
        IQueryable<FireInspectionSchedule> GetByDateRange(DateTime from, DateTime to);

        IQueryable<FireInspectionSchedule> GetByYear(int fireInspectionYear);
    }
}
