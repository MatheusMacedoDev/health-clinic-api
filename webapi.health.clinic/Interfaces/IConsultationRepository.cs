using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Interfaces
{
    public interface IConsultationRepository
    {
        void Create(Consultation consultation);
        List<Consultation> ListAll();
        List<Consultation> GetConsultationByPatient();
        List<Consultation> GetConsultationByDoctor();
        Consultation GetById();
        void Update(Consultation consultation);
        void Delete(Guid id);
    }
}
