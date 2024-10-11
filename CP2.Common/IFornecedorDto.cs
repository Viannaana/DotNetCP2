using System;

namespace CP2.Domain.Interfaces.Dtos
{
    /// <summary>
    /// Interface para Data Transfer Object de Fornecedor.
    /// </summary>
    public interface IFornecedorDto
    {
        /// <summary>
        /// Nome do fornecedor.
        /// </summary>
        string Nome { get; set; }

        /// <summary>
        /// CNPJ do fornecedor.
        /// </summary>
        string CNPJ { get; set; }

        /// <summary>
        /// Endereço do fornecedor.
        /// </summary>
        string Endereco { get; set; }

        /// <summary>
        /// Telefone do fornecedor.
        /// </summary>
        string Telefone { get; set; }

        /// <summary>
        /// Email do fornecedor.
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Data de criação do fornecedor.
        /// </summary>
        DateTime CriadoEm { get; set; }

        /// <summary>
        /// Método para validar o DTO.
        /// </summary>
        void Validate();
    }
}
