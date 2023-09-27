using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeRepository _userTypeRepository;

        public UserTypeController()
        {
            _userTypeRepository = new UserTypeRepository();
        }

        [HttpPost]
        public IActionResult Create(UserType userType)
        {
            try
            {
                _userTypeRepository.Create(userType);

                return StatusCode(201, userType);
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        }

        [HttpGet]
        public IActionResult ListAll()
        {
            try
            {
                List<UserType> userTypes = _userTypeRepository.ListAll();

                return Ok(userTypes);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                UserType userType = _userTypeRepository.GetByIdDefault(id);

                return Ok(userType);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _userTypeRepository.Delete(id);

                return NoContent();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(UserType userType)
        {
            try
            {
                _userTypeRepository.Update(userType);

                return StatusCode(204, userType);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
