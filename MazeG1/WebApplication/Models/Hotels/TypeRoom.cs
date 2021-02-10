using System.ComponentModel;

namespace WebApplication.Models.Hotels
{
    public enum TypeRoom
    {
        [Description("одноместный")]
        Single = 1,
        [Description("двухместный")]
        Double = 2,
        [Description("многоместный")]
        Triple = 3,
        [Description("семейный")]
        Family = 4
    }
}
