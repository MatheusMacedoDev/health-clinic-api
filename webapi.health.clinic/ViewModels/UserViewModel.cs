using System.ComponentModel.DataAnnotations;
using webapi.health.clinic.Domains;

namespace webapi.health.clinic.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Os dados de endereço são obrigatórios!")]
        public Address? Address { get; set; }

        [Required(ErrorMessage = "Os dados do usuário são obrigatórios!")]
        public User? User { get; set; }
    }
}
