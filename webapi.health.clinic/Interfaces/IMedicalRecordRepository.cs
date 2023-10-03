using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Interfaces
{
    public interface IMedicalRecordRepository
    {
        void Create(MedicalRecord medicalRecord);
        MedicalRecord GetById(Guid id);
        void Update(MedicalRecord medicalRecord);
    }
}
