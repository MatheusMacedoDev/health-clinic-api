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
            Doctor findedDoctor = _context.Doctors.FirstOrDefault(doctor => doctor.Id == id)!;

            if (findedDoctor != null)
            {
                _context.Doctors.Remove(findedDoctor);
                _context.SaveChanges();
            }
        }

        public List<Doctor> ListAll()
        {
            return _context.Doctors.Select(doctor => new Doctor
            {
                Id = doctor.Id,
                CRM = doctor.CRM,
                User = new User
                {
                    Id = doctor.User!.Id,
                    Name = doctor.User.Name,
                    Email = doctor.User.Email
                }
            }).ToList();
        }
    }
}
