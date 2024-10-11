using System;

namespace CP2.Domain.Interfaces.Dtos
{
    /// <summary>
    /// Interface que representa um Data Transfer Object (DTO) para um vendedor.
    /// </summary>
    public interface IVendedorDto
    {
        /// <summary>
        /// Identificador único do vendedor.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Nome do vendedor.
        /// </summary>
        string Nome { get; set; }

        /// <summary>
        /// Endereço de e-mail do vendedor.
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Número de telefone do vendedor.
        /// </summary>
        string Telefone { get; set; }

        /// <summary>
        /// Data de nascimento do vendedor.
        /// </summary>
        DateTime DataNascimento { get; set; }

        /// <summary>
        /// Endereço do vendedor.
        /// </summary>
        string Endereco { get; set; }

        /// <summary>
        /// Percentual de comissão do vendedor.
        /// </summary>
        decimal ComissaoPercentual { get; set; }

        /// <summary>
        /// Meta mensal do vendedor.
        /// </summary>
        decimal MetaMensal { get; set; }

        /// <summary>
        /// Método para validar os dados do vendedor.
        /// </summary>
        void Validate();
    }
}
