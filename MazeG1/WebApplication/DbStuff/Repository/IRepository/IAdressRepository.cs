using System.Collections.Generic;
using WebApplication.DbStuff.Model;

namespace WebApplication.DbStuff.Repository
{
    public interface IAdressRepository : IBaseRepository<Adress>
    {
        IEnumerable<Adress> GetAdressByUser(long userId);

        long GetAdressIdDefaultForFireInspection(string city, string street, int houseNumber);

        Adress GetAdressDefaultForFireInspection(string city, string street, int houseNumber);

        Adress GetAdressDefaultForFireInspectionBuilding(string city, string street, int houseNumber);

        Adress GetAdressDefaultForFireInspectionSchedule(string city, string street, int houseNumber);
    }
}