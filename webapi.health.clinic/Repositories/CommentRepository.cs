using webapi.health.clinic.Contexts;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;

namespace webapi.health.clinic.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly HealthClinicContext _context;

        public CommentRepository()
        {
            _context = new HealthClinicContext();
        }

        public void Create(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Comment findedComment = _context.Comments.FirstOrDefault(comment => comment.Id == id)!;

            if (findedComment != null)
            {
                _context.Comments.Remove(findedComment);
                _context.SaveChanges();
            }
        }

        public List<Comment> GetByConsultation(Guid consultationId)
        {
            return _context.Comments.Where(comment => comment.ConsultationId == consultationId).ToList();
        }
    }
}
