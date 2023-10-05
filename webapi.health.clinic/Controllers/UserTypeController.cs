using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    /// <summary>
    /// Controlador dos tipos de usuário
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    //[Authorize(Roles = "Administrador")]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeRepository _userTypeRepository;

        /// <summary>
        /// Construtor dos tipos de usuário
        /// </summary>
        public UserTypeController()
        {
            _userTypeRepository = new UserTypeRepository();
        }

        /// <summary>
        /// Endpoint que cria um novo tipo de usuário
        /// </summary>
        /// <param name="userType">Objeto do tipo de usuário</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpPost]
        public IActionResult Create(UserType userType)
        {
            try
            {
                _userTypeRepository.Create(userType);

                return StatusCode(201, userType);
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        }

        /// <summary>
        /// Endpoint que lista todos os tipos de usuário
        /// </summary>
        /// <returns>Resposta HTTP ao usuário contendo uma lista de tipos de usuário</returns>
        [HttpGet]
        public IActionResult ListAll()
        {
            try
            {
                List<UserType> userTypes = _userTypeRepository.ListAll();

                return Ok(userTypes);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Endpoint que pega um tipo de usuário específico
        /// </summary>
        /// <param name="id">Id do tipo de usuário</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                UserType userType = _userTypeRepository.GetByIdDefault(id);

                return Ok(userType);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Endpoint que remove um tipo de usuário
        /// </summary>
        /// <param name="id">Id do tipo de usuário</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _userTypeRepository.Delete(id);

                return NoContent();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Endpoint que atualiza os dados de um tipo de usuário
        /// </summary>
        /// <param name="userType">Dados do tipo de usuário</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpPut]
        public IActionResult Update(UserType userType)
        {
            try
            {
                _userTypeRepository.Update(userType);

                return StatusCode(204, userType);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
