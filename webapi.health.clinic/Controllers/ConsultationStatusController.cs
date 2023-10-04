using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    //[Authorize(Roles = "Administrador")]
    public class ConsultationStatusController : ControllerBase
    {
        private readonly IConsultationStatusRepository _consultationStatusRepository;

        public ConsultationStatusController()
        {
            _consultationStatusRepository = new ConsultationStatusRepository();
        }

        [HttpPost]
        public IActionResult Create(ConsultationStatus consultationStatus)
        {
            try
            {
                _consultationStatusRepository.Create(consultationStatus);

                return StatusCode(201, consultationStatus);
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
                List<ConsultationStatus> consultationStatus = _consultationStatusRepository.ListAll();

                return Ok(consultationStatus);
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
                _consultationStatusRepository.Delete(id);

                return NoContent();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
