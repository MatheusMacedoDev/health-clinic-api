using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    //[Authorize(Roles = "Administrador")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController()
        {
            _addressRepository = new AddressRepository();
        }

        [HttpPost]
        public IActionResult Create(Address address)
        {
            try
            {
                _addressRepository.Create(address);

                return StatusCode(201, address);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
