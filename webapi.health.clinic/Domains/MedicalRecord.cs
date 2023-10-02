using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health.clinic.Domains
{
    [Table("MedicalRecords")]
    public class MedicalRecord
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR")]
        [Required(ErrorMessage = "O prontuário deve conter alguma descrição", AllowEmptyStrings = false)]
        public string? Text { get; set; }
    }
}
