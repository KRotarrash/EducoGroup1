using System.Collections.Generic;
using System.Linq;
using WebApplication.DbStuff.Model.Hospital;

namespace WebApplication.DbStuff.Repository
{
    public interface IMedicalRecordDetailRepository : IBaseRepository<MedicalRecordDetail>
    {
        IQueryable<MedicalRecordDetail> GetMedicalRecordDetailsForRecord(long recordId);
    }
}