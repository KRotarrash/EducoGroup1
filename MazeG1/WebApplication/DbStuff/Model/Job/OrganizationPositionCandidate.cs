using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DbStuff.Model.Job
{
    public class OrganizationPositionCandidate : BaseModel
    {
        [Required]
        public virtual OrganizationPosition OrganizationPosition { get; set; }

        public virtual SpecialUser User { get; set; }
    }
}
