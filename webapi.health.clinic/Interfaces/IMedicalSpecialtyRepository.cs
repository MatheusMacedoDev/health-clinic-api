using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Interfaces
{
    public interface IMedicalSpecialtyRepository
    {
        void Create(MedicalSpecialty medicalSpecialty);
        List<MedicalSpecialty> ListAll();
        MedicalSpecialty GetById(Guid id);
        void Update(MedicalSpecialty medicalSpecialty);
        void Delete(Guid id);
    }
}
