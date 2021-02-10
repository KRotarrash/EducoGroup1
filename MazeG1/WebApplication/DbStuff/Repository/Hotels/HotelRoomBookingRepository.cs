using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model.Hotels;
using WebApplication.DbStuff.Repository.IRepository.IHotels;

namespace WebApplication.DbStuff.Repository.Hotels
{
    public class HotelRoomBookingRepository : BaseRepository<HotelRoomBooking>, IHotelRoomBookingRepository
    {
        public HotelRoomBookingRepository(WebContext webContext) : base(webContext) { }

        public List<long> GetHotelRoomIdsBookingForDate(DateTime dtmStart, DateTime dtmFinish)
        {
            var rooms = _dbSet
                .Where(x => x.DateStart <= dtmFinish || x.DateFinish >= dtmStart)
                .Select(x => x.HotelRoom.Id)
                .ToList();
            return rooms;
        }
    }
}
