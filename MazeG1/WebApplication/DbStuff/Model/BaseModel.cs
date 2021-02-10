using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DbStuff.Model
{
    public abstract class BaseModel
    {
        public virtual long Id { get; set; }
    }
}
