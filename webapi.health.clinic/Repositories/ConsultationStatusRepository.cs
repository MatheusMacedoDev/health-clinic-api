using webapi.health.clinic.Contexts;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;

namespace webapi.health.clinic.Repositories
{
    public class ConsultationStatusRepository : IConsultationStatusRepository
    {
        private readonly HealthClinicContext _context;

        public ConsultationStatusRepository()
        {
            _context = new HealthClinicContext();
        }

        public void Create(ConsultationStatus consultationStatus)
        {
            _context.ConsultationStatus.Add(consultationStatus);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            ConsultationStatus findedStatus = _context.ConsultationStatus.FirstOrDefault(status => status.Id == id)!;

            _context.Remove(findedStatus);
            _context.SaveChanges();
        }

        public List<ConsultationStatus> ListAll()
        {
            return _context.ConsultationStatus.ToList();
        }
    }
}
