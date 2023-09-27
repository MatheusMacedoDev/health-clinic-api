using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Interfaces
{
    public interface IUserTypeRepository
    {
        void Create(UserType userType);
        List<UserType> ListAll();
        UserType GetByIdDefault(Guid id);
        void Update(UserType userTypeNewData);
        void Delete(Guid id);
    }
}
