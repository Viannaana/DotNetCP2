using CP2.Domain.Entities; // Importa a entidade Vendedor
using CP2.Domain.Interfaces; // Importa as interfaces do repositório
using CP2.Domain.Interfaces.Dtos; // Importa a interface do DTO
using System; // Importa o namespace System para tipos básicos
using System.Collections.Generic; // Importa o namespace para coleções

namespace CP2.Application.Services // Namespace da aplicação para serviços
{
    public class VendedorApplicationService : IVendedorApplicationService
    {
        private readonly IVendedorRepository _repository; // Repositório de vendedores

        public VendedorApplicationService(IVendedorRepository repository)
        {
            _repository = repository; // Injeção de dependência do repositório
        }

        public void SalvarDadosVendedor(IVendedorDto vendedorDto)
        {
            // Valida os dados do vendedor
            vendedorDto.Validate();

            // Cria uma nova entidade de vendedor
            var vendedor = new VendedorEntity
            {
                Nome = vendedorDto.Nome,
                Email = vendedorDto.Email,
                Telefone = vendedorDto.Telefone,
                DataNascimento = vendedorDto.DataNascimento,
                Endereco = vendedorDto.Endereco,
                DataContratacao = DateTime.Now, // Define a data de contratação como a hora atual
                ComissaoPercentual = vendedorDto.ComissaoPercentual,
                MetaMensal = vendedorDto.MetaMensal,
                CriadoEm = DateTime.Now // Define a data de criação como a hora atual
            };

            // Salva o vendedor usando o repositório
            _repository.Add(vendedor);
        }

        public void DeletarDadosVendedor(int id)
        {
            // Remove o vendedor do repositório
            _repository.Remove(id);
        }

        public IEnumerable<VendedorEntity> ObterTodosVendedores()
        {
            // Obtém todos os vendedores
            return _repository.GetAll();
        }

        public VendedorEntity? ObterVendedorPorId(int id)
        {
            // Obtém o vendedor pelo ID
            return _repository.GetById(id);
        }

        public void EditarDadosVendedor(int id, IVendedorDto vendedorDto)
        {
            // Implementação da edição (ainda a ser desenvolvida se necessário)
        }
    }
}
