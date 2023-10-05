using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    /// <summary>
    /// Controlador das consultas
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    //[Authorize]
    public class ConsultationController : ControllerBase
    {
        private readonly IConsultationRepository _consultationRepository;

        /// <summary>
        /// Construtor do controlador das consultas
        /// </summary>
        public ConsultationController()
        {
            _consultationRepository = new ConsultationRepository();
        }

        /// <summary>
        /// Endpoint que agenda uma nova consulta
        /// </summary>
        /// <param name="consultation">Objeto da consulta</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpPost]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Create(Consultation consultation)
        {
            try
            {
                _consultationRepository.Create(consultation);

                return StatusCode(201, consultation);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Endpoint que lista todas as consultas marcadas ou que já foram marcadas anteriormente
        /// </summary>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpGet]
        //[Authorize(Roles = "Administrador")]
        public IActionResult ListAll()
        {
            try
            {
                List<Consultation> consultations = _consultationRepository.ListAll();

                return Ok(consultations);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Endpoint que retorna todas as consultas de um determinado paciente
        /// </summary>
        /// <param name="pacientId">Id do paciente</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpGet("GetByPatient/{pacientId}")]
        //[Authorize(Roles = "Paciente")]
        public IActionResult GetConsultationByPatient(Guid pacientId)
        {
            try
            {
                List<Consultation> consultations = _consultationRepository.GetConsultationByPatient(pacientId);

                return Ok(consultations);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Endpoint que retorna todas as consultas de um determinado médico
        /// </summary>
        /// <param name="doctorId">Id do médico</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpGet("GetByDoctor/{doctorId}")]
        //[Authorize(Roles = "Médico")]
        public IActionResult GetConsultationByDoctor(Guid doctorId)
        {
            try
            {
                List<Consultation> consultations = _consultationRepository.GetConsultationByDoctor(doctorId);

                return Ok(consultations);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Endpoint que retorna os dados de uma consulta específica
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Consultation consultation = _consultationRepository.GetById(id);

                return Ok(consultation);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Atualiza os dados de uma consulta específica
        /// </summary>
        /// <param name="consultation">Dados da consulta</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpPut]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Update(Consultation consultation)
        {
            try
            {
                _consultationRepository.Update(consultation);

                return StatusCode(204, consultation);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Remove uma determinada consulta
        /// </summary>
        /// <param name="id">Id da consulta</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpDelete]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _consultationRepository.Delete(id);

                return NoContent();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
