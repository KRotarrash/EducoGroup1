using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.DbStuff.Model.Firefighters;
using WebApplication.DbStuff.Repository.IRepository.IFirefighters;

namespace WebApplication.DbStuff.Repository.Firefighters
{
    public class FireInspectionScheduleRepository : BaseRepository<FireInspectionSchedule>, IFireInspectionScheduleRepository
    {
        public FireInspectionScheduleRepository(WebContext webContext) : base(webContext) { }       
        
        public IQueryable<FireInspectionSchedule> GetByDateRange(DateTime from, DateTime to)
        {
            return _dbSet.Where(x => x.DateInspectionSchedule > from && x.DateInspectionSchedule < to);
        }

        public IQueryable<FireInspectionSchedule> GetByYear(int fireInspectionYear)
        {
            return _dbSet.Where(x => x.DateInspectionSchedule.Year == fireInspectionYear);
        }        
    }
}
