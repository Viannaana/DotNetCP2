using CP2.Domain.Interfaces.Dtos; // Importa a interface do DTO de fornecedor
using FluentValidation; // Importa a biblioteca FluentValidation para validação
using System; // Importa o namespace System para tipos básicos
using System.Linq; // Importa o namespace System.Linq para consultas

namespace CP2.Application.Dtos // Namespace da aplicação para Data Transfer Objects
{
    // Classe que representa o DTO para fornecedores
    public class FornecedorDto : IFornecedorDto
    {
        public string Nome { get; set; } // Nome do fornecedor
        public string CNPJ { get; set; } // CNPJ do fornecedor
        public string Endereco { get; set; } // Endereço do fornecedor
        public string Telefone { get; set; } // Telefone do fornecedor
        public string Email { get; set; } // Email do fornecedor
        public DateTime CriadoEm { get; set; } // Data de criação do registro

        // Método para validar as propriedades do DTO
        public void Validate()
        {
            var validateResult = new FornecedorDtoValidation().Validate(this); // Realiza a validação
            if (!validateResult.IsValid) // Se a validação falhar
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage))); // Lança uma exceção com os erros
        }
    }

    // Classe interna para validação do DTO de fornecedor
    internal class FornecedorDtoValidation : AbstractValidator<FornecedorDto>
    {
        public FornecedorDtoValidation()
        {
            RuleFor(f => f.Nome).NotEmpty().WithMessage("O nome é obrigatório."); // Valida se o nome não está vazio
            RuleFor(f => f.CNPJ).NotEmpty().WithMessage("O CNPJ é obrigatório."); // Valida se o CNPJ não está vazio
            // Adicione mais regras de validação conforme necessário
        }
    }
}
