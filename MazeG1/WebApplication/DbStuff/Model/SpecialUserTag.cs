using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DbStuff.Model
{
    public class SpecialUserTag : BaseModel
    {
        public virtual SpecialUser User { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
