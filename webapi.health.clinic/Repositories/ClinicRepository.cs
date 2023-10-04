using webapi.health.clinic.Contexts;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;

namespace webapi.health.clinic.Repositories
{
    public class ClinicRepository : IClinicRepository
    {
        private HealthClinicContext _context;

        public ClinicRepository()
        {
            _context = new HealthClinicContext();
        }

        public Clinic GetByIdDefault(Guid id) => _context.Clinics.FirstOrDefault(clinic => clinic.Id == id)!;

        public void Create(Clinic clinic)
        {
            _context.Clinics.Add(clinic);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Clinic findedClinic = GetByIdDefault(id);
            _context.Clinics.Remove(findedClinic);
            _context.SaveChanges();
        }


        public List<Clinic> ListAll()
        {
            return _context.Clinics.Select(clinic => new Clinic
            {
                Id = clinic.Id,
                FancyName = clinic.FancyName,
                CompanyName = clinic.CompanyName,
                OpeningTime = clinic.OpeningTime,
                ClosingTime = clinic.ClosingTime,
                Address = new Address
                {
                    Id = clinic.Address!.Id,
                    Cep = clinic.Address.Cep,
                    Number = clinic.Address.Number
                }
            }).ToList();
        }

        public void Update(Clinic clinicNewData)
        {
            Clinic findedClinic = GetByIdDefault(clinicNewData.Id);

            if (findedClinic != null)
            {
                findedClinic.FancyName = clinicNewData.FancyName;
                findedClinic.CompanyName = clinicNewData.CompanyName;
                findedClinic.OpeningTime = clinicNewData.OpeningTime;
                findedClinic.ClosingTime = clinicNewData.ClosingTime;
                findedClinic.AddressId = clinicNewData.AddressId;

                _context.Clinics.Update(findedClinic);
                _context.SaveChanges();
            }
        }
    }
}
