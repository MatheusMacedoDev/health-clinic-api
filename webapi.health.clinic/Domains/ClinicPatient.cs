using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health.clinic.Domains
{
    /// <summary>
    /// Entidade que relaciona as clínicas e os pacientes
    /// </summary>
    [Table("ClinicPatients")]
    public class ClinicPatient
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        // Clinic Reference

        [Required(ErrorMessage = "A clínica é um item obrigatório")]
        public Guid ClinicId { get; set; }

        [ForeignKey(nameof(ClinicId))]
        public Clinic? Clinic { get; set; }

        // User Reference

        [Required(ErrorMessage = "O paciente é um item obrigatório")]
        public Guid PatientId { get; set; }

        [ForeignKey(nameof(PatientId))]
        public Patient? Patient { get; set; }
    }
}
