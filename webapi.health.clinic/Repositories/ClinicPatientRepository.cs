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

        public List<ClinicPatient> GetPatientsByClinic(Guid clinicId)
        {
            return _context.ClinicPatients
                .Select(clinicPatient => new ClinicPatient
                {
                    Id = clinicPatient.Id,
                    ClinicId = clinicId,
                    Clinic = new Clinic
                    {
                        Id = clinicPatient.ClinicId,
                        FancyName = clinicPatient.Clinic.FancyName
                    },
                    PatientId = clinicPatient.PatientId,
                    Patient = new Patient
                    {
                        Id = clinicPatient.Patient!.Id,
                        User = new User()
                        {
                            Id = clinicPatient.Patient.User.Id,
                            Name = clinicPatient.Patient.User.Name
                        }
                    }
                })
                .Where(clinicPatient => clinicPatient.ClinicId == clinicId)
                .ToList();
        }

        public void Delete(Guid id)
        {
            ClinicPatient findedClinicPatient = _context.ClinicPatients.FirstOrDefault(cp => cp.Id == id)!;

            if (findedClinicPatient != null)
            {
                _context.ClinicPatients.Remove(findedClinicPatient);
                _context.SaveChanges();
            }
        }
    }
}
