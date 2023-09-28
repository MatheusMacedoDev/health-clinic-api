using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController()
        {
            _patientRepository = new PatientRepository();
        }

        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            try
            {
                _patientRepository.Create(patient);

                return Ok(patient);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
