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
            User findedUser = _context.Users.FirstOrDefault(user => user.Email == email)!;

            if (findedUser != null)
            {
                if (findedUser.Password == password)
                {
                    return findedUser;
                }
            }

            return null!;
        }

        public List<User> ListAll()
        {
            return _context.Users.Select(user => new User
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                BirthDate = user.BirthDate.Date,
                PhoneNumber = user.PhoneNumber,
                SomeonePhoneNumber = user.SomeonePhoneNumber,
                UserType = new UserType
                {
                    TypeName = user.UserType.TypeName
                }
            }).ToList();
        }
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
