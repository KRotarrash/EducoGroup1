using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model.Hotels;
using WebApplication.DbStuff.Repository.IRepository.IHotels;

namespace WebApplication.DbStuff.Repository.Hotels
{
    public class HotelRoomRepository : BaseRepository<HotelRoom>, IHotelRoomRepository
    {
        public HotelRoomRepository(WebContext webContext) : base(webContext) { }

    }
}
