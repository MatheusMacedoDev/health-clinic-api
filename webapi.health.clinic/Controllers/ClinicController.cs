using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    //[Authorize]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicRepository _clinicRepository;

        public ClinicController()
        {
            _clinicRepository = new ClinicRepository();
        }

        /// <summary>
        /// Endpoint que lida com a criação de um determinada clínica
        /// </summary>
        /// <param name="clinic">Objeto da clínica</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpPost]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Create(Clinic clinic)
        {
            try
            {
                _clinicRepository.Create(clinic);

                return StatusCode(201, clinic);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Lista todas as clínicas
        /// </summary>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpGet]
        public IActionResult ListAll()
        {
            try
            {
                List<Clinic> clinics = _clinicRepository.ListAll();

                return Ok(clinics);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Endpoint que recebe os dados de uma clínica específica
        /// </summary>
        /// <param name="id">Id da clínica</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Clinic clinic = _clinicRepository.GetByIdDefault(id);

                return Ok(clinic);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Endpoint que remove uma clínica
        /// </summary>
        /// <param name="id">Id da clínica</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpDelete]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _clinicRepository.Delete(id);

                return NoContent();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Endpoint que atualiza os dados de uma clínica
        /// </summary>
        /// <param name="clinic">Dados da clínica</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpPut]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Update(Clinic clinic)
        {
            try
            {
                _clinicRepository.Update(clinic);

                return StatusCode(204, clinic);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
