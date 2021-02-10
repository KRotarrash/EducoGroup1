using System;

namespace WebApplication.DbStuff.Model.Hospital
{
    public class MedicalRecordDetail : BaseModel
    {    
        public virtual MedicalRecord MedicalRecord { get; set; }  

        public virtual DateTime DateOfExamination { get; set; }

        public virtual string ResultOfExamination { get; set; }

        public virtual SpecialUser Doctor { get; set; }
    }
}
