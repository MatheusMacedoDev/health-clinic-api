using webapi.health.clinic.Contexts;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;

namespace webapi.health.clinic.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly HealthClinicContext _context;

        public AddressRepository()
        {
            _context = new HealthClinicContext();
        }

        public void Create(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }
    }
}
