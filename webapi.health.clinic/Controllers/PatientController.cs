using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;
using webapi.health.clinic.ViewModels;

namespace webapi.health.clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PatientController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IClinicPatientRepository _clinicPatientRepository;

        public PatientController()
        {
            _addressRepository = new AddressRepository();
            _userRepository = new UserRepository();
            _patientRepository = new PatientRepository();
            _clinicPatientRepository = new ClinicPatientRepository();
        }

        [HttpPost]
        public IActionResult Create(PatientViewModel data)
        {
            try
            {
                _addressRepository.Create(data.Address!);

                data.User!.AddressId = data.Address.Id;

                _userRepository.Register(data.User!);

                Patient patient = new Patient()
                {
                    UserId = data.User!.Id,
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

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
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
