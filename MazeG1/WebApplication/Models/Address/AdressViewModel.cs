using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models.Address;
using WebApplication.Models.CustomAttribute;

namespace WebApplication.Models
{
    public class AdressViewModel
    {
        public long Id { get; set; }

        [Required]
        [DisplayName("Тип помещения")]
        public virtual TypePlacing TypePlacing { get; set; }

        [Required(ErrorMessage = "Введите страну")]
        [DisplayName("Страна")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Введите город")]
        [DisplayName("Город")]
        public string City { get; set; }

        [Required]
        [DisplayName("Тип улицы")]
        public virtual TypeStreet TypeStreet { get; set; }

        [Required(ErrorMessage = "Введите наименование улицы")]
        [MinLength(5)]
        [MaxAdressCount(3)]
        [DisplayName("Улица")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Введите номер дома")]
        [DisplayName("Номер дома")]
        public int HouseNumber { get; set; }

        [DisplayName("Номер квартиры")]
        public int? FlatNumber { get; set; }

        [DisplayName("Этаж")]
        public int? Floor { get; set; }

        public long OwnerId { get; set; }

        public List<UserViewModel> Users { get; set; }

        public AdressViewModel()
        {
            Country = "Беларусь";
            City = "Минск";
            TypeStreet = TypeStreet.Street;
            TypePlacing = TypePlacing.Living;
        }

        public string FullName
        {
            get
            {
                return $"Город: {City}, Улица/Проспект: {Street}, Номер дома: {HouseNumber}, Номер квартиры/офиса: {FlatNumber}, Этаж: {Floor}";
            }
        }
    }
}
