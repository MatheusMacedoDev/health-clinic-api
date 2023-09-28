using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Interfaces
{
    public interface IClinicPatientRepository
    {
        void Create(ClinicPatient clinicPatient);
        void Delete(Guid id);
    }
}
