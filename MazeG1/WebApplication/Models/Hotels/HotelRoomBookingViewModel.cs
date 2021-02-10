using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApplication.Models.CustomAttribute;
using WebApplication.Models.Hotels;

namespace WebApplication.Models
{
    public class HotelRoomBookingViewModel
    {
        public long Id { get; set; }

        public HotelRoomViewModel HotelRoom { get; set; }

        [Required(ErrorMessage = "Введите дату начала")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Дата начала")]
        public DateTime DateStart { get; set; }

        [Required(ErrorMessage = "Введите дату окончания")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [DateGreaterThan(nameof(DateStart))]
        [DisplayName("Дата окончания")]
        public DateTime DateFinish { get; set; }

        [Required]
        public UserViewModel User { get; set; }

        public List<HotelRoomViewModel> HotelRooms { get; set; }
    }
}