using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    /// <summary>
    /// Controlador do prontuário
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MedicalRecordController : ControllerBase
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;

        /// <summary>
        /// Contrutor do controlador do prontuário
        /// </summary>
        public MedicalRecordController()
        {
            _medicalRecordRepository = new MedicalRecordRepository();
        }

        /// <summary>
        /// Endpoint que cria um novo prontuário
        /// </summary>
        /// <param name="medicalRecord">Objeto de prontuário</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpPost]
        public IActionResult Create(MedicalRecord medicalRecord)
        {
            try
            {
                _medicalRecordRepository.Create(medicalRecord);

                return StatusCode(201, medicalRecord);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Endpoint que recebe os dados de um prontuário
        /// </summary>
        /// <param name="id">Id do prontuário</param>
        /// <returns>Resposta HTTP ao usuário contendo os dados de um prontuário</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                MedicalRecord medicalRecord = _medicalRecordRepository.GetById(id);

                return Ok(medicalRecord);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Endpoint que atualiza os dados de um prontuário
        /// </summary>
        /// <param name="medicalRecord">Dados do prontuário</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpPut]
        public IActionResult Update(MedicalRecord medicalRecord)
        {
            try
            {
                _medicalRecordRepository.Update(medicalRecord);

                return StatusCode(200, medicalRecord);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
