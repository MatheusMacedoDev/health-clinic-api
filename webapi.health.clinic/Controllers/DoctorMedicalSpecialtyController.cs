using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorMedicalSpecialtyController : ControllerBase
    {
        private readonly IDoctorMedicalSpecialtyRepository _doctorMedicalSpecialtyRepository;

        public DoctorMedicalSpecialtyController()
        {
            _doctorMedicalSpecialtyRepository = new DoctorMedicalSpecialtyRepository();
        }

        [HttpPost]
        public IActionResult Create(DoctorMedicalSpecialty doctorMedicalSpecialty)
        {
            try
            {
                _doctorMedicalSpecialtyRepository.Create(doctorMedicalSpecialty);

                return StatusCode(201, doctorMedicalSpecialty);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Endpoint que retorna todas as especialidades de um determinado médico
        /// </summary>
        /// <param name="doctorId">Id do médico</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpGet]
        public IActionResult GetSpecialtiesByDoctor(Guid doctorId)
        {
            try
            {
                List<DoctorMedicalSpecialty> doctorMedicalSpecialties = _doctorMedicalSpecialtyRepository.GetSpecialtiesByDoctor(doctorId);

                return Ok(doctorMedicalSpecialties);
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
                _doctorMedicalSpecialtyRepository.Delete(id);

                return NoContent();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
