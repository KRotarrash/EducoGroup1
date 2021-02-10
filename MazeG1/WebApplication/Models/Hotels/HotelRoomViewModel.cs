using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApplication.Models.Hotels;

namespace WebApplication.Models
{
    public class HotelRoomViewModel
    {
        public long Id { get; set; }

        public HotelViewModel Hotel { get; set; }

        [Required(ErrorMessage = "Введите номер")]
        [DisplayName("Номер")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Введите этаж")]
        [DisplayName("Этаж")]
        public int Floor { get; set; }

        [Required(ErrorMessage = "Выберите тип номера")]
        [DisplayName("Тип номера")]
        public TypeRoom TypeRoom { get; set; }
    }
}