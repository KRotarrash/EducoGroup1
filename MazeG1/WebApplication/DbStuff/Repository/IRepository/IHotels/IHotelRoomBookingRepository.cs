using System;
using System.Collections.Generic;
using WebApplication.DbStuff.Model.Hotels;

namespace WebApplication.DbStuff.Repository.IRepository.IHotels
{
    public interface IHotelRoomBookingRepository : IBaseRepository<HotelRoomBooking>
    {
        List<long> GetHotelRoomIdsBookingForDate(DateTime dtmStart, DateTime dtmFinish);
    }
}
