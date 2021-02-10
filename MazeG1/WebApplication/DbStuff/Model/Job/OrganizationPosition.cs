using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DbStuff.Model.Job
{
    public class OrganizationPosition : BaseModel
    {
        public virtual Organization Organization { get; set; }

        public virtual Position Position { get; set; }

        public virtual List<OrganizationPositionCandidate> Candidates { get; set; }

        public virtual List<SpecialUser> Workers { get; set; }
    }
}
