using WebApplication.DbStuff.Model.Hospital;

namespace WebApplication.DbStuff.Repository
{
    public interface IMedicalRecordRepository : IBaseRepository<MedicalRecord>
    {
        MedicalRecord GetMedicalRecordByPatientId(long userId);
    }
}