using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Interfaces
{
    public interface ICommentRepository
    {
        void Create(Comment comment);
        List<Comment> GetByConsultation(Guid consultationId);
        void Delete(Guid id);
    }
}
