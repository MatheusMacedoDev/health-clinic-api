using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    /// <summary>
    /// Controlador dos estados das consultas
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    //[Authorize(Roles = "Administrador")]
    public class ConsultationStatusController : ControllerBase
    {
        private readonly IConsultationStatusRepository _consultationStatusRepository;

        /// <summary>
        /// Construtor do controlador dos estados das consultas
        /// </summary>
        public ConsultationStatusController()
        {
            _consultationStatusRepository = new ConsultationStatusRepository();
        }

        /// <summary>
        /// Endpoint que cria um novo estado para as consultas
        /// </summary>
        /// <param name="consultationStatus">Objeto de estado da consulta</param>
        /// <returns>Resposta HTTP ao usuário</returns>
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

        /// <summary>
        /// Endpoint que lista todos os estados das consultas
        /// </summary>
        /// <returns>Resposta HTTP ao usuário</returns>
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

        /// <summary>
        /// Endpoint que remove um estado de consulta específico
        /// </summary>
        /// <param name="id">Id do estado de consulta</param>
        /// <returns>Resposta HTTP ao usuário</returns>
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
