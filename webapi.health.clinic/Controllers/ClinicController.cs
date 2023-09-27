using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicRepository _clinicRepository;

        public ClinicController()
        {
            _clinicRepository = new ClinicRepository();
        }

        [HttpPost]
        public IActionResult Create(Clinic clinic)
        {
            try
            {
                _clinicRepository.Create(clinic);

                return StatusCode(201, clinic);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet]
        public IActionResult ListAll()
        {
            try
            {
                List<Clinic> clinics = _clinicRepository.ListAll();

                return Ok(clinics);
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
                Clinic clinic = _clinicRepository.GetByIdDefault(id);

                return Ok(clinic);
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
                _clinicRepository.Delete(id);

                return NoContent();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(Clinic clinic)
        {
            try
            {
                _clinicRepository.Update(clinic);

                return StatusCode(204, clinic);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
