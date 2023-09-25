using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health.clinic.Domains
{
    [Table("Doctors")]
    [Index(nameof(CRM), IsUnique = true)]
    public class Doctor
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column(TypeName = "CHAR(8)")]
        [Required(ErrorMessage = "O CRM do médico é obrigatório")]
        public string? CRM { get; set; }

        // User Reference

        [Required(ErrorMessage = "O usuário é obrigatório para o médico")]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
    }
}
