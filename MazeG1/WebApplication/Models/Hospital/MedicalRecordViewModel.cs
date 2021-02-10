using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;

namespace WebApplication.Models
{
    public class MedicalRecordViewModel
    {
        public long Id { get; set; }

        public UserViewModel Patient { get; set; }

        public DateTime DateOfLastExamination { get; set; }
    }
}
