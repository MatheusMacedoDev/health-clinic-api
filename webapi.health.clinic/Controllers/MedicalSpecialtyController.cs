using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MedicalSpecialtyController : ControllerBase
    {
        private readonly IMedicalSpecialtyRepository _medicalSpecialtyRepository;

        public MedicalSpecialtyController()
        {
            _medicalSpecialtyRepository = new MedicalSpecialtyRepository();
        }

        [HttpPost]
        public IActionResult Create(MedicalSpecialty medicalSpecialty)
        {
            try
            {
                _medicalSpecialtyRepository.Create(medicalSpecialty);

                return StatusCode(201, medicalSpecialty);
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
                List<MedicalSpecialty> medicalSpecialties = _medicalSpecialtyRepository.ListAll();

                return Ok(medicalSpecialties);
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
                MedicalSpecialty medicalSpecialty = _medicalSpecialtyRepository.GetById(id);

                return Ok(medicalSpecialty);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _medicalSpecialtyRepository.Delete(id);

                return NoContent();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
