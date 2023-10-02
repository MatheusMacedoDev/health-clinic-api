using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClinicPatientController : ControllerBase
    {
        private readonly IClinicPatientRepository _clinicPatientRepository;

        public ClinicPatientController()
        {
            _clinicPatientRepository = new ClinicPatientRepository();
        }

        [HttpPost]
        public IActionResult Create(ClinicPatient clinicPatient)
        {
            try
            {
                _clinicPatientRepository.Create(clinicPatient);

                return StatusCode(201, clinicPatient);
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
                _clinicPatientRepository.Delete(id);

                return NoContent();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
