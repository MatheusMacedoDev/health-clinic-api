using System.ComponentModel.DataAnnotations;

namespace webapi.health.clinic.ViewModels
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "O nome do usuário é um item obrigatório", AllowEmptyStrings = false)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "O e-mail do usuário é um item obrigatório", AllowEmptyStrings = false)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A senha do usuário é obrigatória")]
        [MinLength(8)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "A data de nascimento do usuário é obrigatório")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "O número de telefone do usuário é obrigatório", AllowEmptyStrings = false)]
        [MinLength(11)]
        public string? PhoneNumber { get; set; }

        [MinLength(11)]
        public string? SomeonePhoneNumber { get; set; }

        // UserType Reference

        [Required(ErrorMessage = "O tipo do usuário é obrigatório")]
        public Guid UserTypeId { get; set; }

        // Address Reference

        [Required(ErrorMessage = "O endereço do usuário é obrigatório")]
        public Guid AddressId { get; set; }
    }
}
