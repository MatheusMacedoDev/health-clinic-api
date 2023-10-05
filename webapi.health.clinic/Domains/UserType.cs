using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health.clinic.Domains
{
    /// <summary>
    /// Entidade que representa um tipo de usuário
    /// </summary>
    [Table("UserTypes")]
    [Index(nameof(TypeName), IsUnique = true)]
    public class UserType
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(32)")]
        [Required(ErrorMessage = "O nome do tipo de usuário é um item obrigatório")]
        public string? TypeName { get; set; }
    }
}
