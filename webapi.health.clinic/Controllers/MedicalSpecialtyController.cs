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
    }
}
