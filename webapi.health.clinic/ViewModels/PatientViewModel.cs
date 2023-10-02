using System.ComponentModel.DataAnnotations;
using webapi.health.clinic.Domains;

namespace webapi.health.clinic.ViewModels
{
    public class PatientViewModel
    {
        [Required(ErrorMessage = "Os dados do usuário são obrigatórios!")]
        public UserViewModel? UserViewModel { get; set; }

        [Required(ErrorMessage = "Os dados da clínica são obrigatórios!")]
        public ClinicPatient? ClinicPatient { get; set; }
    }
}
