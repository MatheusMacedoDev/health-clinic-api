using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    /// <summary>
    /// Controlador dos comentários
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    //[Authorize]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        /// <summary>
        /// Construtor do CommentController
        /// </summary>
        public CommentController()
        {
            _commentRepository = new CommentRepository();
        }

        /// <summary>
        /// Endpoint que cria um comentário
        /// </summary>
        /// <param name="comment">Objeto do comentário</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpPost]
        //[Authorize(Roles = "Paciente")]
        public IActionResult Create(Comment comment)
        {
            try
            {
                _commentRepository.Create(comment);

                return StatusCode(201, comment);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Endpoint que recebe os dados de todos comentários de uma consulta
        /// </summary>
        /// <param name="consultationId">Id da consulta</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpGet("{consultationId}")]
        public IActionResult GetByConsultation(Guid consultationId)
        {
            try
            {
                List<Comment> comments = _commentRepository.GetByConsultation(consultationId);

                return Ok(comments);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Endpoint que exclui um determinado comentário
        /// </summary>
        /// <param name="id">Id do comentário</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Paciente")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _commentRepository.Delete(id);

                return NoContent();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
