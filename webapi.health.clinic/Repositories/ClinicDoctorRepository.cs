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
            ClinicDoctor findedClinicDoctor = _context.ClinicDoctors.FirstOrDefault(clinicDoctor => clinicDoctor.Id == id)!;

            if (findedClinicDoctor != null)
            {
                _context.ClinicDoctors.Remove(findedClinicDoctor);
                _context.SaveChanges();
            }
        }

        public List<ClinicDoctor> GetDoctorsByClinic(Guid clinicId)
        {
            return _context.ClinicDoctors
                .Where(clinicDoctor => clinicDoctor.ClinicId == clinicId)
                .Select(clinicDoctor => new ClinicDoctor
                {
                    Id = clinicDoctor.Id,
                    Doctor = new Doctor
                    {
                        Id = clinicDoctor.Doctor!.Id,
                        User = new User
                        {
                            Id = clinicDoctor.Doctor.User!.Id,
                            Name = clinicDoctor.Doctor.User.Name
                        }
                    },
                    Clinic = new Clinic
                    {
                        Id = clinicDoctor.Clinic!.Id,
                        FancyName = clinicDoctor.Clinic.FancyName,
                        CompanyName = clinicDoctor.Clinic.CompanyName,
                        OpeningTime = clinicDoctor.Clinic.OpeningTime,
                        ClosingTime = clinicDoctor.Clinic.ClosingTime,
                        Address = new Address
                        {
                            Id = clinicDoctor.Clinic.Address!.Id,
                            Cep = clinicDoctor.Clinic.Address.Cep,
                            Number = clinicDoctor.Clinic.Address.Number
                        }

                    }
                }).ToList();
        }
    }
}
