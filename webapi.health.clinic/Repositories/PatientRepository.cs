using webapi.health.clinic.Contexts;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;

namespace webapi.health.clinic.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HealthClinicContext _context;

        public PatientRepository()
        {
            _context = new HealthClinicContext();
        }

        public void Create(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Patient> ListAll()
        {
            throw new NotImplementedException();
        }
    }
}
