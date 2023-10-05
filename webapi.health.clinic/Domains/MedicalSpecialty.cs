using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health.clinic.Domains
{
    /// <summary>
    /// Entidade que representa uma especialidade médica
    /// </summary>
    [Table("MedicalSpecialties")]
    [Index(nameof(Name), IsUnique = true)]
    public class MedicalSpecialty
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(40)")]
        [Required(ErrorMessage = "O nome da especialidade é obrigatório")]
        public string? Name { get; set; }
    }
}
