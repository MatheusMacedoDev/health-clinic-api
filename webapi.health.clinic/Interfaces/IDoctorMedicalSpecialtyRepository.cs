using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Interfaces
{
    public interface IDoctorMedicalSpecialtyRepository
    {
        void Create(DoctorMedicalSpecialty doctorMedicalSpecialty);
        List<DoctorMedicalSpecialty> GetSpecialtiesByDoctor(Guid doctorId);
        void Delete(Guid id);
    }
}
