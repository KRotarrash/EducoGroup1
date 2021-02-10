using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DbStuff.Institutions
{
    public enum OrderState
    {
        Сanceled = 0,
        InBasket = 1,
        New = 2,
        Confirmed = 3,
        Completed = 4  
    }
}
