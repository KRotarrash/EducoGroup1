using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DbStuff.Model.Job
{
    public class Position : BaseModel
    {        
        [Required]
        public virtual string Name { get; set; }
        public virtual List<OrganizationPosition> OrganizationPositions { get; set; }
        public virtual double Salary { get; set; }
        public virtual Office Office { get; set; }
    }
}
