using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Models.Hotels;

namespace WebApplication.DbStuff.Model.Hotels
{
    public class HotelRoom : BaseModel
    {    
        [Required]
        public virtual Hotel Hotel { get; set; }

        public virtual int Number { get; set; }  

        public virtual int Floor { get; set; }

        public virtual TypeRoom TypeRoom { get; set; }

        public virtual List<HotelRoomBooking> Bookings { get; set; }
    }
}
