using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApplication.DbStuff.Model;
using WebApplication.Models.CustomAttribute;

namespace WebApplication.Models
{
    public class HotelViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Заполните наименование")]
        [MinLength(3, ErrorMessage = "Наименование должно содержать не менее 3 символов")]
        [UniqHotelName]
        [DisplayName("Наименование")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Выберите владельца")]
        [DisplayName("Владелец")]
        public UserViewModel Owner { get; set; }

        public long OwnerId { get; set; }

        public List<UserViewModel> Helpers { get; set; }

        public List<HotelRoomViewModel> Rooms { get; set; }

        public List<UserViewModel> Users { get; set; }
    }
}
