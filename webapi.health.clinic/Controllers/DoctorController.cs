using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorController()
        {
            _doctorRepository = new DoctorRepository();
        }

        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            try
            {
                _doctorRepository.Create(doctor);

                return StatusCode(201, doctor);
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
                List<Doctor> doctors = _doctorRepository.ListAll();

                return Ok(doctors);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
