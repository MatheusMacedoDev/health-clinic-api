using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Interfaces
{
    public interface IConsultationStatusRepository
    {
        void Create(ConsultationStatus consultationStatus);
        List<ConsultationStatus> ListAll();
        void Delete(Guid id);
    }
}
