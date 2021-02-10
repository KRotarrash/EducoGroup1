using System.ComponentModel.DataAnnotations;

namespace WebApplication.DbStuff.Institutions
{
    public enum DishType
    {
        [Display(Name = "Неопределённый")]
        Undefined = 1,
        [Display(Name = "Закуски")]
        Appetizers = 2,
        [Display(Name = "Холодные закуски")]
        ColdPlatter = 3,
        [Display(Name = "Горячие закуски")]
        HotAppetizers = 4,
        [Display(Name = "Супы")]
        Soups = 5,
        [Display(Name = "Салаты")]
        Salads = 6,
        [Display(Name = "Безалкогольные напитки")]
        SoftDrinks = 7,
        [Display(Name = "Спиртное")]
        HotDrinks = 8
    }
}