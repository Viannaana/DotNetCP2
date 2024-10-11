using CP2.Domain.Interfaces.Dtos;
using FluentValidation;
using System;
using System.Linq;

namespace CP2.Common.Dtos
{
    public class FornecedorDto : IFornecedorDto
    {
        public string Nome { get; set; } = string.Empty; // Inicializando com um valor padrão
        public string CNPJ { get; set; } = string.Empty; // Inicializando com um valor padrão
        public string Endereco { get; set; } = string.Empty; // Inicializando com um valor padrão
        public string Telefone { get; set; } = string.Empty; // Inicializando com um valor padrão
        public string Email { get; set; } = string.Empty; // Inicializando com um valor padrão
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow; // Inicializando com data padrão

        public void Validate()
        {
            var validateResult = new FornecedorDtoValidation().Validate(this);
            if (!validateResult.IsValid)
                throw new ValidationException(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class FornecedorDtoValidation : AbstractValidator<FornecedorDto>
    {
        public FornecedorDtoValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(f => f.CNPJ)
                .NotEmpty().WithMessage("O CNPJ é obrigatório.")
                .Matches(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}$").WithMessage("O CNPJ deve estar no formato XX.XXX.XXX/XXXX-XX.");

            RuleFor(f => f.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O formato do email é inválido.");

            RuleFor(f => f.Telefone)
                .MaximumLength(15).WithMessage("O telefone deve ter no máximo 15 caracteres.");

            RuleFor(f => f.Endereco)
                .MaximumLength(200).WithMessage("O endereço deve ter no máximo 200 caracteres.");
        }
    }
}
