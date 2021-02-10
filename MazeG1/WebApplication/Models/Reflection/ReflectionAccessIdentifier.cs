using System.ComponentModel;
using System.Collections.Generic;

namespace WebApplication.Models.Reflection
{
    public enum AccessIdentifier
    {
        [Description("public")]
        Identpublic = 1,
        [Description("private")]
        Identprivate = 2,
        [Description("static")]
        Identstatic = 3
    }
}
