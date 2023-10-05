using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;
using webapi.health.clinic.ViewModels;

namespace webapi.health.clinic.Controllers
{
    /// <summary>
    /// Controlador do paciente
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    //[Authorize(Roles = "Administrador")]
    public class PatientController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IClinicPatientRepository _clinicPatientRepository;


        /// <summary>
        /// Construtor do controlador do paciente
        /// </summary>
        public PatientController()
        {
            _addressRepository = new AddressRepository();
            _userRepository = new UserRepository();
            _patientRepository = new PatientRepository();
            _clinicPatientRepository = new ClinicPatientRepository();
        }

        /// <summary>
        /// Cria um paciente com todos os dados necessários
        /// </summary>
        /// <param name="data">Dados do paciente</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpPost]
        public IActionResult Create(PatientViewModel data)
        {
            try
            {
                _addressRepository.Create(data.UserViewModel!.Address!);

                data.UserViewModel!.User!.AddressId = data.UserViewModel.Address!.Id;

                _userRepository.Register(data.UserViewModel!.User!);

                Patient patient = new Patient()
                {
                    UserId = data.UserViewModel!.User.Id,
                };

                _patientRepository.Create(patient);

                data.ClinicPatient!.PatientId = patient.Id;

                _clinicPatientRepository.Create(data.ClinicPatient!);

                return Ok(data);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Endpoint que lista todos os pacientes
        /// </summary>
        /// <returns>Resposta HTTP ao usuário contendo uma lista de pacientes</returns>
        [HttpGet]
        public IActionResult ListAll()
        {
            try
            {
                List<Patient> patients = _patientRepository.ListAll();

                return Ok(patients);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Endpoint que pega todos os pacientes de um determinada clínica
        /// </summary>
        /// <param name="clinicId">Id da clínica</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpGet("{clinicId}")]
        public IActionResult GetPatientsByClinic(Guid clinicId)
        {
            try
            {
                List<ClinicPatient> clinicPatients = _clinicPatientRepository.GetPatientsByClinic(clinicId);

                return Ok(clinicPatients);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Endpoint que remove um paciente
        /// </summary>
        /// <param name="id">Id do paciente</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _clinicPatientRepository.DeleteAllByPatient(id);
                _patientRepository.Delete(id);

                return NoContent();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
