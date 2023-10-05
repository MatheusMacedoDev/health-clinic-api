using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health.clinic.Domains
{
    /// <summary>
    /// Entidade que representa um comentário
    /// </summary>
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column(TypeName = "Date")]
        public DateTime Date { get; set; } = DateTime.Now.Date;

        [Column(TypeName = "VARCHAR(300)")]
        [Required(ErrorMessage = "O comentário deve conter algum texto", AllowEmptyStrings = false)]
        [StringLength(300, MinimumLength = 1)]
        public string? Text { get; set; }

        [Column(TypeName = "BIT")]
        public bool IsValidated { get; set; } = false;

        // Consultation Reference

        [Required(ErrorMessage = "É obrigatório definir uma consulta a ser comentada")]
        public Guid ConsultationId { get; set; }

        [ForeignKey(nameof(ConsultationId))]
        public Consultation? Consultation { get; set; }
    }
}
