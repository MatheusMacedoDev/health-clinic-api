using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Interfaces
{
    public interface IClinicRepository
    {
        void Create(Clinic clinic);
        List<Clinic> ListAll();
        Clinic GetByIdDefault(Guid id);
        void Update(Clinic clinicNewData);
        void Delete(Guid id);
    }
}
