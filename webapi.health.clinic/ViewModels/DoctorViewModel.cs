using System.ComponentModel.DataAnnotations;
using webapi.health.clinic.Domains;

namespace webapi.health.clinic.ViewModels
{
    public class DoctorViewModel
    {
        [Required(ErrorMessage = "Os dados do usuário são obrigatórios!")]
        public UserViewModel? UserViewModel { get; set; }

        [Required(ErrorMessage = "Os dados do médico são obrigatórios!")]
        public Doctor? Doctor { get; set; }

        [Required(ErrorMessage = "Os dados da clínica são obrigatórios!")]
        public ClinicDoctor? ClinicDoctor { get; set; }

        [Required(ErrorMessage = "Os dados da clínica são obrigatórios!")]
        public List<DoctorMedicalSpecialty>? DoctorMedicalSpecialties { get; set; }
    }
}
