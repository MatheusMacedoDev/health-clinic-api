using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Interfaces
{
    public interface IPatientRepository
    {
        void Create(Patient patient);
        List<Patient> ListAll();
        void Delete(Guid id);
    }
}
