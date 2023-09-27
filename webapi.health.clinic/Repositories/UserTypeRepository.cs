using Microsoft.EntityFrameworkCore;
using webapi.health.clinic.Contexts;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;

namespace webapi.health.clinic.Repositories
{
    public class UserTypeRepository : IUserTypeRepository
    {
        private readonly HealthClinicContext _context;

        public UserTypeRepository()
        {
            _context = new HealthClinicContext();
        }

        public void Create(UserType userType)
        {
            _context.UserTypes.Add(userType);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            UserType findedUserType = GetByIdDefault(id);
            _context.UserTypes.Remove(findedUserType);
            _context.SaveChanges();
        }

        public UserType GetByIdDefault(Guid id)
        {
            return _context.UserTypes.FirstOrDefault(userType => userType.Id == id)!;
        }

        public List<UserType> ListAll()
        {
            return _context.UserTypes.Select(userType => new UserType
            {
                Id = userType.Id,
                TypeName = userType.TypeName
            }).ToList();
        }

        public void Update(UserType userTypeNewData)
        {
            UserType findedUserType = GetByIdDefault(userTypeNewData.Id);

            if (findedUserType != null)
            {
                findedUserType.TypeName = userTypeNewData.TypeName;

                _context.UserTypes.Update(findedUserType);
                _context.SaveChanges();
            }
        }
    }
}
