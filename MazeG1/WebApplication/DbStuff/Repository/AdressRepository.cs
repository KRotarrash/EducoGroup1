using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;

namespace WebApplication.DbStuff.Repository
{
    public class AdressRepository : BaseRepository<Adress>, IAdressRepository
    {
        public AdressRepository(WebContext webContext) : base(webContext) { }

        public IEnumerable<Adress> GetAdressByUser(long userId)
        {
            return _dbSet.Where(x => x.Users.Any(y => y.User.Id == userId));
        }

        public long GetAdressIdDefaultForFireInspection(string city, string street, int houseNumber)
        {
            return _dbSet
                .FirstOrDefault(x => x.City == city && x.Street == street && x.HouseNumber == houseNumber)
                .Id;
        }

        public Adress GetAdressDefaultForFireInspection(string city, string street, int houseNumber)
        {
            return _dbSet
                .FirstOrDefault(x => x.City == city && x.Street == street && x.HouseNumber == houseNumber);
        }

        public Adress GetAdressDefaultForFireInspectionBuilding(string city, string street, int houseNumber)
        {
            return _dbSet.FirstOrDefault(x => x.FireInspectionBuilding.Any(y => y.BuildingAdress.City == city &&
              y.BuildingAdress.Street == street && y.BuildingAdress.HouseNumber == houseNumber));
        }

        public Adress GetAdressDefaultForFireInspectionSchedule(string city, string street, int houseNumber)
        {
            return _dbSet.FirstOrDefault(x => x.FireInspectionSchedule.BuildingAdress.City == city && 
              x.FireInspectionSchedule.BuildingAdress.Street == street && x.FireInspectionSchedule.BuildingAdress.HouseNumber == houseNumber);
        }
    }
}
