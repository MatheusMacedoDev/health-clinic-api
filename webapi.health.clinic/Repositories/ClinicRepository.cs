using webapi.health.clinic.Contexts;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;

namespace webapi.health.clinic.Repositories
{
    public class ClinicRepository : IClinicRepository
    {
        private HealthClinicContext _context;

        public ClinicRepository()
        {
            _context = new HealthClinicContext();
        }

        public void Create(Clinic clinic)
        {
            _context.Clinics.Add(clinic);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Clinic> ListAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Clinic clinicNewData)
        {
            throw new NotImplementedException();
        }
    }
}
