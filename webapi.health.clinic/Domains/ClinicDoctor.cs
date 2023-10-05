using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health.clinic.Domains
{
    /// <summary>
    /// Entidade que representa a relação entre os médicos e as clínicas
    /// </summary>
    [Table("ClinicDoctors")]
    public class ClinicDoctor
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        // Clinic Reference

        [Required(ErrorMessage = "A clínica é um item obrigatório")]
        public Guid ClinicId { get; set; }

        [ForeignKey(nameof(ClinicId))]
        public Clinic? Clinic { get; set; }

        // Doctor Reference

        [Required(ErrorMessage = "O médico é um item obrigatório")]
        public Guid DoctorId { get; set; }

        [ForeignKey(nameof(DoctorId))]
        public Doctor? Doctor { get; set; }
    }
}
