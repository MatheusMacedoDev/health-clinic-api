using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health.clinic.Domains
{
    /// <summary>
    /// Entidade que representa a clínica
    /// </summary>
    [Table("Clinics")]
    public class Clinic
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(30)")]
        [Required(ErrorMessage = "O nome fantasia da clínica é um item obrigatório")]
        public string? FancyName { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "A razão social da clínica é um item obrigatório")]
        public string? CompanyName { get; set; }

        [Column(TypeName = "Time")]
        [Required(ErrorMessage = "O horário de abertura da clínica é um item obrigatório")]
        public TimeSpan OpeningTime { get; set; }
        
        [Column(TypeName = "Time")]
        [Required(ErrorMessage = "O horário de fechamento da clínica é um item obrigatório")]
        public TimeSpan ClosingTime { get; set; } 

        // Address Reference

        [Required(ErrorMessage = "O endereço da clínica é um item obrigatório")]
        public Guid AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        public Address? Address { get; set; }
    }
}
