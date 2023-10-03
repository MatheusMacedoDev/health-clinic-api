using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health.clinic.Domains
{
    [Table("ConsultationStatus")]
    public class ConsultationStatus
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(32)")]
        [Required(ErrorMessage = "O estado da consulta deve possuir um nome", AllowEmptyStrings = false)]
        public string? StatusName { get; set; }
    }
}
