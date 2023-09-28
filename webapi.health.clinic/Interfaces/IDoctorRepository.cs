using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Interfaces
{
    public interface IDoctorRepository
    {
        void Create(Doctor doctor);
        List<Doctor> ListAll();
        void Delete(Guid id); 
    }
}
