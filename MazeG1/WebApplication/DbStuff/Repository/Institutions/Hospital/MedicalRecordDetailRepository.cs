using System.Collections.Generic;
using System.Linq;
using WebApplication.DbStuff.Model.Hospital;

namespace WebApplication.DbStuff.Repository
{
    public class MedicalRecordDetailRepository : BaseRepository<MedicalRecordDetail>, IMedicalRecordDetailRepository
    {
        public MedicalRecordDetailRepository(WebContext webContext) : base(webContext) { }

        public IQueryable<MedicalRecordDetail> GetMedicalRecordDetailsForRecord(long recordId)
        {
            return _dbSet.Where(x => x.MedicalRecord.Id == recordId);
        }
    }
}
