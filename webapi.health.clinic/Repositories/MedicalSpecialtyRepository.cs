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
            MedicalSpecialty findedMedicalSpecialty = GetById(id);

            if (findedMedicalSpecialty != null)
            {
                _context.MedicalSpecialties.Remove(findedMedicalSpecialty);
                _context.SaveChanges();
            }
        }

        public MedicalSpecialty GetById(Guid id)
        {
            return _context.MedicalSpecialties.FirstOrDefault(specialty => specialty.Id == id)!;
        }

        public List<MedicalSpecialty> ListAll()
        {
            return _context.MedicalSpecialties.ToList();
        }

        public void Update(MedicalSpecialty medicalSpecialty)
        {
            MedicalSpecialty findedMedicalSpecialty = GetById(medicalSpecialty.Id);

            if (findedMedicalSpecialty != null)
            {
                findedMedicalSpecialty.Name = medicalSpecialty.Name;

                _context.MedicalSpecialties.Update(findedMedicalSpecialty);
                _context.SaveChanges();
            }
        }
    }
}
