using System;
using System.ComponentModel.DataAnnotations;

namespace CP2.Domain.Entities
{
    public class FornecedorEntity
    {
        [Key]
        public int Id { get; set; } // Identificador único do fornecedor

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres.")]
        public string Nome { get; set; } = string.Empty; // Nome do fornecedor

        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [MaxLength(18, ErrorMessage = "O CNPJ não pode ter mais que 18 caracteres.")]
        public string CNPJ { get; set; } = string.Empty; // CNPJ do fornecedor

        [MaxLength(200, ErrorMessage = "O endereço não pode ter mais que 200 caracteres.")]
        public string Endereco { get; set; } = string.Empty; // Endereço do fornecedor

        [MaxLength(15, ErrorMessage = "O telefone não pode ter mais que 15 caracteres.")]
        public string Telefone { get; set; } = string.Empty; // Telefone do fornecedor

        [MaxLength(100, ErrorMessage = "O email não pode ter mais que 100 caracteres.")]
        [EmailAddress(ErrorMessage = "O formato do email é inválido.")]
        public string Email { get; set; } = string.Empty; // Email do fornecedor

        public DateTime CriadoEm { get; set; } = DateTime.UtcNow; // Data de criação do fornecedor
    }
}
