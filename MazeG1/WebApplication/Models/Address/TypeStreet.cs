using System.ComponentModel;

namespace WebApplication.Models.Address
{
    public enum TypeStreet
    {
        [Description("улица")]
        Street = 1,
        [Description("шоссе")]
        Highway = 2,
        [Description("переулок")]
        Lane = 3,
        [Description("проспект")]
        Avenue = 4
    }
}
