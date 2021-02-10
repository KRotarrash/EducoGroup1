using System.Collections.Generic;
using WebApplication.DbStuff.Model.Job;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApplication.Models.CustomAttribute;

namespace WebApplication.Models.Job
{
    public class OfficeViewModel
    {
        public long Id { get; set; }
        [DisplayName("Название офиса")]
        [Required(ErrorMessage = "Заполните имя офиса")]
        [MinLength(5, ErrorMessage = "Имя офиса должно содержать не менее 5 символов")]
        [UniqOfficeName]
        public virtual string Name { get; set; }
        public long CurrentAdressId { get; set; }
        public long CurrentOrganizationId { get; set; }
        public bool IsAnyAddress { get; set; }
        [DisplayName("Тип офиса")]
        [Required(ErrorMessage = "Выбирите тип офиса")]
        public virtual OfficeType OfficeType { get; set; }
        [DisplayName("Адрес")]
        public virtual AdressViewModel Address { get; set; }
        public virtual List<AdressViewModel> Addresses { get; set; }
        public virtual List<OrganizationViewModel> Organizations { get; set; }
    }
}
