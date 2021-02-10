using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Localization;

namespace WebApplication.Service
{
    public class LocalizeService
    {
        public void Tet()
        {
            var cultureInfo = CultureInfo.GetCultureInfo("en-US");
            Home.Culture = cultureInfo;
        }
    }
}
