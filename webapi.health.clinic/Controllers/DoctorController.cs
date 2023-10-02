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
    public class DoctorController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IUserRepository _userRepository;
        private readonly IClinicDoctorRepository _clinicDoctorRepository;
        private readonly IDoctorMedicalSpecialtyRepository _doctorMedicalSpecialtyRepository;
        private readonly IDoctorRepository _doctorRepository;
        public DoctorController()
        {
            _addressRepository = new AddressRepository();
            _userRepository = new UserRepository();
            _clinicDoctorRepository = new ClinicDoctorRepository();
            _doctorMedicalSpecialtyRepository = new DoctorMedicalSpecialtyRepository();
            _doctorRepository = new DoctorRepository();
        }

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
