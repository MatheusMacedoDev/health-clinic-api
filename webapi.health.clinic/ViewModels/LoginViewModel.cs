using System.ComponentModel.DataAnnotations;

namespace webapi.health.clinic.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O e-mail do usuário é um item obrigatório", AllowEmptyStrings = false)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A senha do usuário é obrigatória")]
        //[MinLength(8)]
        public string? Password { get; set; }
    }
}
