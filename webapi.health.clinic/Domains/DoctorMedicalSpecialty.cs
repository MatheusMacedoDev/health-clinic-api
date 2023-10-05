using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health.clinic.Domains
{
    /// <summary>
    /// Entidade que representa a relação entre médicos e suas especialidades
    /// </summary>
    [Table("DoctorMedicalSpecialties")]
    public class DoctorMedicalSpecialty
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        // Doctor Reference

        [Required(ErrorMessage = "O médico é um campo obrigatório")]
        public Guid DoctorId { get; set; }

        [ForeignKey(nameof(DoctorId))]
        public Doctor? Doctor { get; set; }

        // Medical Specialty Reference

        [Required(ErrorMessage = "A especialidade médica é um campo obrigatório")]
        public Guid MedicalSpecialtyId { get; set; }

        [ForeignKey(nameof(MedicalSpecialtyId))]
        public MedicalSpecialty? MedicalSpecialty { get; set; }
    }
}
