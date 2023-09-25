using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health.clinic.Domains
{
    [Table("Users")]
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O nome do usuário é um item obrigatório", AllowEmptyStrings = false)]
        public string? Name { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O e-mail do usuário é um item obrigatório", AllowEmptyStrings = false)]
        public string? Email { get; set; }

        [Column(TypeName = "CHAR(60)")]
        [Required(ErrorMessage = "A senha do usuário é obrigatória", AllowEmptyStrings = false)]
        [MinLength(8)]
        public string? Password { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data de nascimento do usuário é obrigatório")]
        public DateTime BirthDate { get; set; }

        [Column(TypeName = "CHAR(11)")]
        [Required(ErrorMessage = "O número de telefone do usuário é obrigatório", AllowEmptyStrings = false)]
        [MinLength(11)]
        public string? PhoneNumber { get; set; }

        [Column(TypeName = "CHAR(11)")]
        [MinLength(11)]
        public string? SomeonePhoneNumber { get; set; }

        // UserType Reference

        [Required(ErrorMessage = "O tipo do usuário é obrigatório")]
        public Guid UserTypeId { get; set; }

        [ForeignKey(nameof(UserTypeId))]
        public UserType? UserType { get; set; }

        // Address Reference

        [Required(ErrorMessage = "O endereço do usuário é obrigatório")]
        public Guid AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        public Address? Address { get; set; }
    }
}
