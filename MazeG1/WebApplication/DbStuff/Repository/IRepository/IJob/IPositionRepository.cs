using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model.Job;
using WebApplication.Models;

namespace WebApplication.DbStuff.Repository.IRepository.IJob
{
    public interface IPositionRepository : IBaseRepository<Position>
    {
        Position GetPositionByName(string name);
    }
}
