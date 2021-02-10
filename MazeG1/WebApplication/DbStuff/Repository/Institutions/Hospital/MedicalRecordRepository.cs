using System.Linq;
using WebApplication.DbStuff.Model.Hospital;

namespace WebApplication.DbStuff.Repository
{
    public class MedicalRecordRepository : BaseRepository<MedicalRecord>, IMedicalRecordRepository
    {
        public MedicalRecordRepository(WebContext webContext) : base(webContext) { }

        public MedicalRecord GetMedicalRecordByPatientId(long userId)
        {
            return _dbSet.FirstOrDefault(x => x.Patient.Id == userId);
        }
    }
}
