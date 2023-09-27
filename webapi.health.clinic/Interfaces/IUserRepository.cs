using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Interfaces
{
    public interface IUserRepository
    {
        void Register(User user);
        List<User> ListAll();
        User GetByEmailAndPassword(string email, string password);
        void Delete(Guid id);
    }
}
