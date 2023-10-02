using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController()
        {
            _commentRepository = new CommentRepository();
        }

        [HttpPost]
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

        [HttpDelete("{id}")]
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
