using webapi.health.clinic.Contexts;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;

namespace webapi.health.clinic.Repositories
{
    public class ClinicPatientRepository : IClinicPatientRepository
    {
        private readonly HealthClinicContext _context;

        public ClinicPatientRepository()
        {
            _context = new HealthClinicContext();
        }

        public void Create(ClinicPatient clinicPatient)
        {
            _context.ClinicPatients.Add(clinicPatient);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
