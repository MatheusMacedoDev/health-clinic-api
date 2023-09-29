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
            return _context.DoctorMedicalSpecialties
                .Where(dm => dm.DoctorId == doctorId)
                .Select(dm => new DoctorMedicalSpecialty
                {
                    Id = dm.Id,
                    Doctor = new Doctor
                    {
                        Id = dm.Doctor!.Id,
                        User = new User
                        {
                            Id = dm.Doctor.User!.Id,
                            Name = dm.Doctor.User.Name
                        }
                    },
                    MedicalSpecialty = new MedicalSpecialty
                    {
                        Id = dm.MedicalSpecialty!.Id,
                        Name = dm.MedicalSpecialty.Name
                    }
                })
                .ToList();
        }
    }
}
