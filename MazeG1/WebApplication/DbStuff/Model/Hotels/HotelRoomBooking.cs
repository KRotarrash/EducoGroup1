using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Models.Hotels;

namespace WebApplication.DbStuff.Model.Hotels
{
    public class HotelRoomBooking : BaseModel
    {    
        [Required]
        public virtual HotelRoom HotelRoom { get; set; }

        public virtual SpecialUser User { get; set; }

        public virtual DateTime DateStart { get; set; }

        public virtual DateTime DateFinish { get; set; } 
    }
}
