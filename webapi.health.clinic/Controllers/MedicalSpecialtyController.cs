using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    /// <summary>
    /// Controlador das especialidades médicas
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    //[Authorize(Roles = "Administrador")]
    public class MedicalSpecialtyController : ControllerBase
    {
        private readonly IMedicalSpecialtyRepository _medicalSpecialtyRepository;

        /// <summary>
        /// Construtor do controlador das especialidades médicas
        /// </summary>
        public MedicalSpecialtyController()
        {
            _medicalSpecialtyRepository = new MedicalSpecialtyRepository();
        }

        /// <summary>
        /// Endpoint que cria uma especialidade médica
        /// </summary>
        /// <param name="medicalSpecialty">Objeto da especialidade médica</param>
        /// <returns>Resposta HTTP ao usuário</returns>
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

        /// <summary>
        /// Endpoint que lista todas as especialidades médicas
        /// </summary>
        /// <returns>Resposta HTTP ao usuário contendo a lista das especialidades</returns>
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

        /// <summary>
        /// Endpoint que pega uma especialidade médica específica
        /// </summary>
        /// <param name="id">Id da especialidade médica</param>
        /// <returns>Resposta HTTP ao usuário contendo os dados da especialidade</returns>
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

        /// <summary>
        /// Endpoint que remove uma especialidade médica
        /// </summary>
        /// <param name="id">Id da especialidade médica</param>
        /// <returns>Resposta HTTP ao usuário</returns>
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

        /// <summary>
        /// Endpoint que atualiza os dados de uma especialidade médica
        /// </summary>
        /// <param name="medicalSpecialty">Dados da especialidade</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpPut]
        public IActionResult Update(MedicalSpecialty medicalSpecialty)
        {
            try
            {
                _medicalSpecialtyRepository.Update(medicalSpecialty);

                return StatusCode(200, medicalSpecialty);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
