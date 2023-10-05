using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;
using webapi.health.clinic.ViewModels;

namespace webapi.health.clinic.Controllers
{
    /// <summary>
    /// Controlador do usuário
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    //[Authorize(Roles = "Administrador")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Construtor do controlador do usuário
        /// </summary>
        public UserController()
        {
            _userRepository = new UserRepository();
        }

        /// <summary>
        /// Endpoint que registra um novo usuário
        /// </summary>
        /// <param name="data">Dados do usuário</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpPost]
        public IActionResult Register(UserRegisterViewModel data)
        {
            try
            {
                _userRepository.Register(data);

                return StatusCode(201, data);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Endpoint que lista todos os usuários
        /// </summary>
        /// <returns>Resposta HTTP ao usuário contendo uma lista de usuários</returns>
        [HttpGet] 
        public IActionResult ListAll()
        {
            try
            {
                List<User> users = _userRepository.ListAll();

                return Ok(users);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Endpoint que remove um usuário
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _userRepository.Delete(id);

                return NoContent();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
