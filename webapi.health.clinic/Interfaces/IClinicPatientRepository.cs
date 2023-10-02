using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Interfaces
{
    public interface IClinicPatientRepository
    {
        void Create(ClinicPatient clinicPatient);
        List<ClinicPatient> GetPatientsByClinic(Guid clinicId);
        void DeleteAllByPatient(Guid PatientId);
        void Delete(Guid id);
    }
}
