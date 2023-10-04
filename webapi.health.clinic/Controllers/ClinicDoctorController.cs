using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
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

        /// <summary>
        /// Endpoint que recebe todos os médicos de uma clínica
        /// </summary>
        /// <param name="clinicId">Id da clínica</param>
        /// <returns>Resposta HTTP ao usuário</returns>
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

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _clinicDoctorRepository.Delete(id);

                return NoContent();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
