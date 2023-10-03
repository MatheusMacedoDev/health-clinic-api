using webapi.health.clinic.Contexts;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;

namespace webapi.health.clinic.Repositories
{
    public class ConsultationRepository : IConsultationRepository
    {
        private readonly HealthClinicContext _context;

        public ConsultationRepository()
        {
            _context = new HealthClinicContext();
        }

        public void Create(Consultation consultation)
        {
            _context.Consultations.Add(consultation);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Consultation GetById()
        {
            throw new NotImplementedException();
        }

        public List<Consultation> GetConsultationByDoctor()
        {
            throw new NotImplementedException();
        }

        public List<Consultation> GetConsultationByPatient()
        {
            throw new NotImplementedException();
        }

        public List<Consultation> ListAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Consultation consultation)
        {
            throw new NotImplementedException();
        }
    }
}
