using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health.clinic.Domains
{
    [Table("Consultations")]
    public class Consultation
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column(TypeName = "Date")]
        [Required(ErrorMessage = "A consulta deve possuir uma data")]
        public DateTime Date { get; set; }

        [Column(TypeName = "Time")]
        [Required(ErrorMessage = "A consulta deve possuir um horário")]
        public TimeSpan Time { get; set; }

        // Clinic Reference

        [Required(ErrorMessage = "É necessário definir a clínica onde ocorrerá a consulta")]
        public Guid ClinicId { get; set; }

        [ForeignKey(nameof(ClinicId))]
        public Clinic? Clinic { get; set; }

        // Patient Reference

        [Required(ErrorMessage = "É necessário definir o paciente da consulta")]
        public Guid PatientId { get; set; }

        [ForeignKey(nameof(PatientId))]
        public Patient? Patient { get; set; }

        // Doctor/MedicalSpecialty Reference

        [Required(ErrorMessage = "É necessário definir o médico da consulta com sua devida especialidade")]
        public Guid DoctorMedicalSpecialtyId { get; set; }

        [ForeignKey(nameof(DoctorMedicalSpecialtyId))]
        public DoctorMedicalSpecialty? DoctorMedicalSpecialty { get; set; }

        // Medical Record Reference
        public Guid MedicalRecordId { get; set; }

        [ForeignKey(nameof(MedicalRecordId))]
        public MedicalRecord? MedicalRecord { get; set; }

        // Consultation Status Reference

        [Required(ErrorMessage = "É necessário definir o status da consulta")]
        public Guid ConsultationStatusId { get; set; }

        [ForeignKey(nameof(ConsultationStatusId))]
        public ConsultationStatus? ConsultationStatus { get; set; }
    }
}
