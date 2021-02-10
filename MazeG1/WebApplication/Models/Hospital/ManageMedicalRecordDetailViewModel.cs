using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;

namespace WebApplication.Models
{
    public class ManageMedicalRecordDetailViewModel
    {
        public long MedicalRecordId { get; set; }

        public long PatientId { get; set; }

        public string PatientName { get; set; }

        public List<MedicalRecordDetailViewModel> Details { get; set; }

        public PaginatorInfoViewModel PaginatorInfo { get; set; }

        public SortViewModel SortViewModel { get; set; }
    }
}
