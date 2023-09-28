using webapi.health.clinic.Contexts;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;

namespace webapi.health.clinic.Repositories
{
    public class DoctorMedicalSpecialtyRepository : IDoctorMedicalSpecialtyRepository
    {
        private readonly HealthClinicContext _context;

        public DoctorMedicalSpecialtyRepository()
        {
            _context = new HealthClinicContext();
        }

        public void Create(DoctorMedicalSpecialty doctorMedicalSpecialty)
        {
            _context.DoctorMedicalSpecialties.Add(doctorMedicalSpecialty);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<DoctorMedicalSpecialty> GetSpecialtiesByDoctor(Guid doctorId)
        {
            throw new NotImplementedException();
        }
    }
}
