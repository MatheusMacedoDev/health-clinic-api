using webapi.health.clinic.Contexts;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;

namespace webapi.health.clinic.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly HealthClinicContext _context;

        public DoctorRepository()
        {
            _context = new HealthClinicContext();
        }

        public void Create(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> ListAll()
        {
            throw new NotImplementedException();
        }
    }
}
