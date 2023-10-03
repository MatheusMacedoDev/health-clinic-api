using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Interfaces
{
    public interface IClinicDoctorRepository
    {
        void Create(ClinicDoctor clinicDoctor);
        List<ClinicDoctor> GetDoctorsByClinic(Guid doctorId);
        void Delete(Guid id);
    }
}
