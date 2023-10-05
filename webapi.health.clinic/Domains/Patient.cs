using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health.clinic.Domains
{
    /// <summary>
    /// Entidade que representa um paciente
    /// </summary>
    [Table("Patients")]
    public class Patient
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        // User Reference

        [Required(ErrorMessage = "O usuário é obrigatório para o paciente")]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
    }
}
