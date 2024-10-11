using System;
using System.ComponentModel.DataAnnotations;

namespace CP2.Domain.Entities
{
    public class VendedorEntity
    {
        [Key]
        public int Id { get; set; } // Identificador único do vendedor

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres.")]
        public string Nome { get; set; } = string.Empty; // Nome do vendedor

        [MaxLength(100, ErrorMessage = "O email não pode ter mais que 100 caracteres.")]
        [EmailAddress(ErrorMessage = "O formato do email é inválido.")]
        public string Email { get; set; } = string.Empty; // Email do vendedor

        [MaxLength(15, ErrorMessage = "O telefone não pode ter mais que 15 caracteres.")]
        public string Telefone { get; set; } = string.Empty; // Telefone do vendedor

        [DataType(DataType.Date)] // Especifica que esta propriedade é uma data
        public DateTime DataNascimento { get; set; } // Data de nascimento do vendedor

        [MaxLength(200, ErrorMessage = "O endereço não pode ter mais que 200 caracteres.")]
        public string Endereco { get; set; } = string.Empty; // Endereço do vendedor

        [DataType(DataType.Date)] // Especifica que esta propriedade é uma data
        public DateTime DataContratacao { get; set; } = DateTime.UtcNow; // Data de contratação do vendedor

        [Range(0, 100, ErrorMessage = "A comissão percentual deve estar entre 0 e 100.")]
        public decimal ComissaoPercentual { get; set; } // Percentual de comissão do vendedor

        [Range(0, double.MaxValue, ErrorMessage = "A meta mensal deve ser um valor positivo.")]
        public decimal MetaMensal { get; set; } // Meta mensal do vendedor

        public DateTime CriadoEm { get; set; } = DateTime.UtcNow; // Data de criação do vendedor
    }
}
