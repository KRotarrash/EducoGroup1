using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DbStuff.Model
{
    public class Tag : BaseModel
    {
        public string Name { get; set; }

        public virtual List<SpecialUserTag> Users { get; set; }
    }
}
