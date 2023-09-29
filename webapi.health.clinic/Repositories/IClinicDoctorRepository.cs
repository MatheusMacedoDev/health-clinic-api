using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Repositories
{
    public interface IClinicDoctorRepository
    {
        void Create(ClinicDoctor clinicDoctor);
        List<ClinicDoctor> ListDoctorsByClinic();
        void Delete(Guid id);
    }
}
