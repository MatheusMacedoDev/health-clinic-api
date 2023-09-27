using webapi.health.clinic.Contexts;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;

namespace webapi.health.clinic.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HealthClinicContext _context;

        public UserRepository()
        {
            _context = new HealthClinicContext();
        }

        public void Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            throw new NotImplementedException();
        }

        public List<User> ListAll()
        {
            throw new NotImplementedException();
        }
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
