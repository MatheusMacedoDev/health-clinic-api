using webapi.health.clinic.Contexts;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Utils;
using webapi.health.clinic.ViewModels;

namespace webapi.health.clinic.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HealthClinicContext _context;

        public UserRepository()
        {
            _context = new HealthClinicContext();
        }

        public void Register(UserRegisterViewModel data)
        {
            byte[] salt = Cryptography.CreateSalt();
            byte[] password = Cryptography.HashPassword(data.Password!, salt);

            User user = new User
            {
                Name = data.Name,
                Email = data.Email,
                Password = password,
                Salt = salt,
                BirthDate = data.BirthDate,
                PhoneNumber = data.PhoneNumber,
                SomeonePhoneNumber = data.SomeonePhoneNumber,
                UserTypeId = data.UserTypeId,
                AddressId = data.AddressId
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            User findedUser = _context.Users.FirstOrDefault(user => user.Email == email)!;

            if (findedUser != null)
            {
                if (Cryptography.VerifyHash(password, findedUser.Salt!, findedUser.Password!))
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
            User findedUser = _context.Users.FirstOrDefault(user => user.Id == id)!;

            if (findedUser != null)
            {
                _context.Users.Remove(findedUser);
                _context.SaveChanges();
            }
        }
    }
}
