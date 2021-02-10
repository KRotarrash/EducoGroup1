using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DbStuff.Model.Hospital
{
    public class MedicalRecord : BaseModel
    {    
        [Required] 
        public virtual SpecialUser Patient { get; set; }

        public virtual long PatientId { get; set; }

        public virtual List<MedicalRecordDetail> Examinations { get; set; }
    }
}
