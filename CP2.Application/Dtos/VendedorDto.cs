using CP2.Domain.Interfaces.Dtos; // Importa a interface do DTO de vendedor
using FluentValidation; // Importa a biblioteca FluentValidation para validação


namespace CP2.Application.Dtos // Namespace da aplicação para Data Transfer Objects
{
    // Classe que representa o DTO para vendedores
    public class VendedorDto : IVendedorDto
    {
        public int Id { get; set; } // Identificador do vendedor
        public string Nome { get; set; } // Nome do vendedor
        public string Email { get; set; } // Email do vendedor
        public string Telefone { get; set; } // Telefone do vendedor
        public DateTime DataNascimento { get; set; } // Data de nascimento do vendedor
        public string Endereco { get; set; } // Endereço do vendedor
        public DateTime DataContratacao { get; set; } // Data de contratação do vendedor
        public decimal ComissaoPercentual { get; set; } // Percentual de comissão do vendedor
        public decimal MetaMensal { get; set; } // Meta mensal do vendedor
        public DateTime CriadoEm { get; set; } // Data de criação do registro

        // Método para validar as propriedades do DTO
        public void Validate()
        {
            var validationResult = new VendedorDtoValidation().Validate(this); // Realiza a validação
            if (!validationResult.IsValid) // Se a validação falhar
                throw new Exception(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage))); // Lança uma exceção com os erros
        }
    }

    // Classe interna para validação do DTO de vendedor
    internal class VendedorDtoValidation : AbstractValidator<VendedorDto>
    {
        public VendedorDtoValidation()
        {
            RuleFor(x => x.Nome).NotEmpty().MaximumLength(100); // Valida se o nome não está vazio e tem um tamanho máximo
            RuleFor(x => x.Email).EmailAddress().NotEmpty(); // Valida se o email é válido e não está vazio
            RuleFor(x => x.Telefone).NotEmpty().Length(10, 15); // Valida se o telefone não está vazio e tem um comprimento válido
            RuleFor(x => x.ComissaoPercentual).GreaterThan(0); // Valida se a comissão percentual é maior que zero
            RuleFor(x => x.MetaMensal).GreaterThan(0); // Valida se a meta mensal é maior que zero
        }
    }
}
