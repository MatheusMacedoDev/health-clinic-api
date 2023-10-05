using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health.clinic.Domains
{
    /// <summary>
    /// Entidade de endereço
    /// </summary>
    [Table("Addresses")]
    public class Address
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column(TypeName = "CHAR(8)")]
        [Required(ErrorMessage = "O CEP é um item obrigatório em um endereço")]
        [MinLength(8, ErrorMessage = "Todo CEP possui exatamente oito digitos")]
        public string? Cep { get; set; }

        [Column(TypeName = "CHAR(2)")]
        [Required(ErrorMessage = "A UF é um item obrigatório em um endereço")]
        [MinLength(2, ErrorMessage = "Toda UF possui exatamente dois digitos")]
        public string? Uf { get; set; }
        
        [Column(TypeName = "VARCHAR(30)")]
        [Required(ErrorMessage = "A cidade é um item obrigatório em um endereço")]
        public string? City { get; set; }

        [Column(TypeName = "VARCHAR(32)")]
        [Required(ErrorMessage = "O bairro é um item obrigatório em um endereço")]
        public string? Neighborhood  { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "A rua é um item obrigatório em um endereço")]
        public string? Street { get; set; }

        [Column(TypeName = "VARCHAR(5)")]
        [Required(ErrorMessage = "O número é um item obrigatório em um endereço")]
        public string? Number { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        public string? Complement { get; set; }
    }
}
