using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApplication.Models.CustomAttribute;

namespace WebApplication.Models
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public long AddressId { get; set; }
        [Required(ErrorMessage = "Заполните имя")]
        [UserName(ErrorMessage = "Не правильное имя. Не забудьте указать имя организации")]
        [MinLength(3, ErrorMessage = "Имя пользователя должно содержать не менее 3 символов")]
        [UniqUserName]
        [DisplayName("Логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [MinLength(6, ErrorMessage = "Пароль должен содержать не менее 6 символов")]
        [Password]
        [DisplayName("Пароль")]
        public string Password { get; set; }

        [Min(18)]
        [DisplayName("Возраст")]
        public int Age { get; set; }

        [Min(10)]
        [DisplayName("Рост")]
        public int Height { get; set; }

        public int AdressCount { get; set; }

        public string Role { get; set; }

        public List<TagViewModel> Tags { get; set; }

        public string ReturnUrl { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [MinLength(6, ErrorMessage = "Пароль должен содержать не менее 6 символов")]
        [DisplayName("Повторите пароль")]
        [Compare("Password", ErrorMessage = "\"Пароль\" и \"Повторить пароль\" не совпадают")]
        public string PasswordRepeat { get; set; }
        public List<OrganizationViewModel> Organizations { get; set; }
        public long PositionId { get; set; }
        public long OrganizationId { get; set; }
        public OrganizationPositionViewModel OrganizationPosition { get; set; }
        [DisplayName("Адрес")]
        public AdressViewModel? Аddress { get; set; }
        public List<AdressViewModel> Аddresses { get; set; }
        public DateTime DateBlocked { get; set; }
        public DateTime EndBlocked { get; set; }

        public long PartnerId { get; set; }

        public string PartnerUserName { get; set; }

        public List<NotificationViewModel> Notifications { get; set; }
    }
}
