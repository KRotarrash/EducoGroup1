using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DbStuff.Model
{
    public class SpecialUserAddress : BaseModel
    {
        public virtual SpecialUser User { get; set; }
        public virtual Adress Adress { get; set; }
    }
}
