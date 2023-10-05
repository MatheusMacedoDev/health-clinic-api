using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;
using webapi.health.clinic.ViewModels;

namespace webapi.health.clinic.Controllers
{
    /// <summary>
    /// Controlador dos médicos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    //[Authorize(Roles = "Administrador")]
    public class DoctorController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IUserRepository _userRepository;
        private readonly IClinicDoctorRepository _clinicDoctorRepository;
        private readonly IDoctorMedicalSpecialtyRepository _doctorMedicalSpecialtyRepository;
        private readonly IDoctorRepository _doctorRepository;

        /// <summary>
        /// Construtor do controlador dos médicos
        /// </summary>
        public DoctorController()
        {
            _addressRepository = new AddressRepository();
            _userRepository = new UserRepository();
            _clinicDoctorRepository = new ClinicDoctorRepository();
            _doctorMedicalSpecialtyRepository = new DoctorMedicalSpecialtyRepository();
            _doctorRepository = new DoctorRepository();
        }

        /// <summary>
        /// Endpoint que cria um novo médico com todos dados necessários
        /// </summary>
        /// <param name="data">Dados do médico</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpPost]
        public IActionResult Create(DoctorViewModel data)
        {
            try
            {
                // Address create
                _addressRepository.Create(data.UserViewModel!.Address!);

                // User create
                data.UserViewModel!.User!.AddressId = data.UserViewModel.Address!.Id;
                _userRepository.Register(data.UserViewModel!.User!);

                // Doctor create
                data.Doctor!.UserId = data.UserViewModel.User!.Id;
                _doctorRepository.Create(data.Doctor!);

                // Make the relationship with Clinic
                data.ClinicDoctor!.DoctorId = data.Doctor!.Id;
                _clinicDoctorRepository.Create(data.ClinicDoctor!);

                // Make the relationship with MedicalSpecialty
                foreach(DoctorMedicalSpecialty doctorMedicalSpecialty in data.DoctorMedicalSpecialties!)
                {
                    doctorMedicalSpecialty.DoctorId = data.Doctor.Id;
                    _doctorMedicalSpecialtyRepository.Create(doctorMedicalSpecialty);
                }

                return StatusCode(201, data);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Endpoint que lista todos os médicos
        /// </summary>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpGet]
        public IActionResult ListAll()
        {
            try
            {
                List<Doctor> doctors = _doctorRepository.ListAll();

                return Ok(doctors);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Endpoint que recebe todos os médicos de uma clínica
        /// </summary>
        /// <param name="clinicId">Id da clínica</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpGet("DoctorsByClinic/{clinicId}")]
        public IActionResult GetDoctorsByClinic(Guid clinicId)
        {
            try
            {
                List<ClinicDoctor> clinicDoctors = _clinicDoctorRepository.GetDoctorsByClinic(clinicId);

                return Ok(clinicDoctors);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Endpoint que remove um médico específico
        /// </summary>
        /// <param name="id">Id do médico</param>
        /// <returns>Resposta HTTP ao usuário</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _doctorRepository.Delete(id);

                return NoContent();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
