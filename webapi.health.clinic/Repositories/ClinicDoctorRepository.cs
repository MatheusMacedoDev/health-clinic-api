using webapi.health.clinic.Contexts;
using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Repositories
{
    public class ClinicDoctorRepository : IClinicDoctorRepository
    {
        private readonly HealthClinicContext _context;

        public ClinicDoctorRepository()
        {
            _context = new HealthClinicContext();
        }

        public void Create(ClinicDoctor clinicDoctor)
        {
            _context.ClinicDoctors.Add(clinicDoctor);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ClinicDoctor> ListDoctorsByClinic()
        {
            throw new NotImplementedException();
        }
    }
}
