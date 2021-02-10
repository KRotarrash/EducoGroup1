using System.ComponentModel.DataAnnotations;

namespace WebApplication.DbStuff.Model.Job
{
    public enum OfficeType
    {
        [Display(Name = "Главный")]
        Main = 1,
        [Display(Name = "Филиал")]
        Branch = 2
    }
}
