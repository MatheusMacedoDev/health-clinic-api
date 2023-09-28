using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Interfaces
{
    public interface IClinicPatientRepository
    {
        void Create(ClinicPatient clinicPatient);
        List<ClinicPatient> GetPatientsByClinic(Guid clinicId);
        void Delete(Guid id);
    }
}
