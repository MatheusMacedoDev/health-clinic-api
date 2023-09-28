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

        [HttpGet]
        public IActionResult ListAll()
        {
            try
            {
                List<Patient> patients = _patientRepository.ListAll();

                return Ok(patients);
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
                _patientRepository.Delete(id);

                return NoContent();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
