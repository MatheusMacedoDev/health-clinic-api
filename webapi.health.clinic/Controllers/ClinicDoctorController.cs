using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClinicDoctorController : ControllerBase
    {
        private readonly IClinicDoctorRepository _clinicDoctorRepository;

        public ClinicDoctorController()
        {
            _clinicDoctorRepository = new ClinicDoctorRepository();
        }

        [HttpPost]
        public IActionResult Create(ClinicDoctor clinicDoctor)
        {
            try
            {
                _clinicDoctorRepository.Create(clinicDoctor);

                return StatusCode(201, clinicDoctor);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet]
        public IActionResult GetDoctorByClinic(Guid clinicId)
        {
            try
            {
                List<ClinicDoctor> clinicDoctors = _clinicDoctorRepository.GetDoctorsByClinic(clinicId);

                return Ok(clinicDoctors);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
