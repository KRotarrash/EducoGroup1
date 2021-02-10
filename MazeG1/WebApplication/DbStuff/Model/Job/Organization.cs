using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DbStuff.Model.Job
{
    public class Organization : BaseModel
    {    
        [Required]
        public virtual string Name { get; set; }

        public virtual DateTime StartWork { get; set; }

        public virtual DateTime EndWork { get; set; }

        public virtual int SalaryDate { get; set; }

        public virtual List<OrganizationPosition> OrganizationPositions { get; set; }

        public virtual OrganizationType OrganizationType { get; set; }

        public virtual SpecialUser Owner { get; set; }

        public virtual List<Office> Offices { get; set; }
    }
}
