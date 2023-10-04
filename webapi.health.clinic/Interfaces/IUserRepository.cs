using webapi.health.clinic.Domains;
using webapi.health.clinic.ViewModels;

namespace webapi.health.clinic.Interfaces
{
    public interface IUserRepository
    {
        void Register(UserRegisterViewModel data);
        List<User> ListAll();
        User GetByEmailAndPassword(string email, string password);
        void Delete(Guid id);
    }
}
