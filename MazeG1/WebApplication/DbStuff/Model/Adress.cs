using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model.Job;
using WebApplication.Models;
using WebApplication.Models.Address;
using WebApplication.DbStuff.Model.Firefighters;

namespace WebApplication.DbStuff.Model
{
    public class Adress : BaseModel
    {
        public virtual TypePlacing TypePlacing { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public virtual TypeStreet TypeStreet { get; set; }

        public string Street { get; set; }

        public int HouseNumber { get; set; }

        public int? FlatNumber { get; set; }

        public int? Floor { get; set; }

        public virtual List<SpecialUserAddress> Users { get; set; }

        public virtual List<Office> Offices { get; set; }

        /// <summary>
        /// Информация об осмотре зданий
        /// </summary>
        public virtual List<FireInspectionBuilding> FireInspectionBuilding { get; set; }

        /// <summary>
        /// График осмотра зданий
        /// </summary>
        public virtual FireInspectionSchedule FireInspectionSchedule { get; set; }
    }
}
