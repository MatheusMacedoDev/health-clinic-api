using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ConsultationController : ControllerBase
    {
        private readonly IConsultationRepository _consultationRepository;

        public ConsultationController()
        {
            _consultationRepository = new ConsultationRepository();
        }

        [HttpPost]
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

        [HttpGet]
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

        [HttpGet("GetByPatient/{pacientId}")]
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

        [HttpGet("GetByDoctor/{doctorId}")]
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
    }
}
