using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Interfaces
{
    public interface IClinicRepository
    {
        void Create(Clinic clinic);
        List<Clinic> ListAll();
        void Update(Clinic clinicNewData);
        void Delete(Guid id);
    }
}
