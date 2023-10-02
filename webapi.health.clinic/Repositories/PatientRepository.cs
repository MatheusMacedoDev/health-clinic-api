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
            try
            {
                Patient findedPatient = _context.Patients.FirstOrDefault(patient => patient.Id == id)!;

                if (findedPatient != null)
                {
                    _context.Patients.Remove(findedPatient);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Patient> ListAll()
        {
            return _context.Patients.Select(patient => new Patient
            {
                Id = patient.Id,
                User = new User
                {
                    Name = patient.User!.Name, 
                    Email = patient.User!.Email
                }
            }).ToList();
        }
    }
}
