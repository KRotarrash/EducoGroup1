using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DbStuff.Model.Hotels
{
    public class Hotel : BaseModel
    {    
        [Required]
        public virtual string Name { get; set; }  

        public virtual SpecialUser Owner { get; set; }

        public virtual List<SpecialUser> Helpers { get; set; }

        public virtual List<HotelRoom> Rooms { get; set; }
    }
}
