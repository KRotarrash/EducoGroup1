using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;

namespace WebApplication.Models
{
    public class MedicalRecordDetailViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Не введена дата осмотра")]
        [DisplayName("Дата осмотра")]
        public DateTime DateOfExamination { get; set; }

        [Required(ErrorMessage = "Не введен результат осмотра")]
        [DisplayName("Результат осмотра")]
        public string ResultOfExamination { get; set; }

        [Required(ErrorMessage = "Не выбран пациент из списка")]
        [DisplayName("Пациет")]
        public long PatientId { get; set; }

        public List<UserViewModel> Users { get; set; }

        public long DoctorId { get; set; }

        [DisplayName("Врач")]
        public string DoctorName { get; set; }
    }
}
