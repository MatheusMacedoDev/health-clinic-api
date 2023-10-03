using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Interfaces
{
    public interface IConsultationRepository
    {
        void Create(Consultation consultation);
        List<Consultation> ListAll();
        List<Consultation> GetConsultationByPatient(Guid pacientId);
        List<Consultation> GetConsultationByDoctor(Guid doctorId);
        Consultation GetById();
        void Update(Consultation consultation);
        void Delete(Guid id);
    }
}
