using System.ComponentModel;

namespace WebApplication.Models.Address
{
    public enum TypePlacing
    {
        [Description("офисное помещение")]
        Office = 1,
        [Description("торговое помещение")]
        Trade = 2,
        [Description("склад")]
        Storehouse = 3,
        [Description("жилое помещение")]
        Living = 4,
        [Description("производство")]
        Production = 5
    }
}
