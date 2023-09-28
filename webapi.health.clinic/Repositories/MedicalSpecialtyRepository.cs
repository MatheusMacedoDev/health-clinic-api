using webapi.health.clinic.Contexts;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;

namespace webapi.health.clinic.Repositories
{
    public class MedicalSpecialtyRepository : IMedicalSpecialtyRepository
    {
        private readonly HealthClinicContext _context;

        public MedicalSpecialtyRepository()
        {
            _context = new HealthClinicContext();
        }

        public void Create(MedicalSpecialty medicalSpecialty)
        {
            _context.MedicalSpecialties.Add(medicalSpecialty);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public MedicalSpecialty GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<MedicalSpecialty> ListAll()
        {
            throw new NotImplementedException();
        }

        public void Update(MedicalSpecialty medicalSpecialty)
        {
            throw new NotImplementedException();
        }
    }
}
