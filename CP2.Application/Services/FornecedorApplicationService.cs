using CP2.Domain.Entities; // Importa a entidade Fornecedor
using CP2.Domain.Interfaces; // Importa as interfaces do repositório
using CP2.Domain.Interfaces.Dtos; // Importa a interface do DTO
using System; // Importa o namespace System para tipos básicos
using System.Collections.Generic; // Importa o namespace para coleções
using System.Linq; // Importa o namespace para consultas LINQ

namespace CP2.Application.Services // Namespace da aplicação para serviços
{
    public class FornecedorApplicationService : IFornecedorApplicationService
    {
        private readonly IFornecedorRepository _fornecedorRepository; // Repositório de fornecedores

        public FornecedorApplicationService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository; // Injeção de dependência do repositório
        }

        public FornecedorEntity? SalvarDadosFornecedor(IFornecedorDto dto)
        {
            // Verifica se o DTO é nulo
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto)); // Lança exceção se o DTO for nulo
            }

            // Cria uma nova entidade de fornecedor
            var fornecedor = new FornecedorEntity
            {
                Nome = dto.Nome,
                CNPJ = dto.CNPJ,
                Endereco = dto.Endereco,
                Telefone = dto.Telefone,
                Email = dto.Email,
                CriadoEm = DateTime.UtcNow // Define a data de criação como a hora atual em UTC
            };

            // Salva o fornecedor no repositório
            _fornecedorRepository.Add(fornecedor);
            _fornecedorRepository.SaveChanges(); // Persiste as mudanças no banco de dados

            return fornecedor; // Retorna o fornecedor criado
        }

        public FornecedorEntity? EditarDadosFornecedor(int id, IFornecedorDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto)); // Lança exceção se o DTO for nulo
            }

            // Obtém o fornecedor pelo ID
            var fornecedor = _fornecedorRepository.GetById(id);
            if (fornecedor == null)
            {
                return null; // Retorna null se o fornecedor não for encontrado
            }

            // Atualiza as propriedades do fornecedor
            fornecedor.Nome = dto.Nome;
            fornecedor.CNPJ = dto.CNPJ;
            fornecedor.Endereco = dto.Endereco;
            fornecedor.Telefone = dto.Telefone;
            fornecedor.Email = dto.Email;

            // Atualiza o fornecedor no repositório
            _fornecedorRepository.Update(fornecedor);
            _fornecedorRepository.SaveChanges(); // Persiste as mudanças

            return fornecedor; // Retorna o fornecedor atualizado
        }

        public FornecedorEntity? DeletarDadosFornecedor(int id)
        {
            // Obtém o fornecedor pelo ID
            var fornecedor = _fornecedorRepository.GetById(id);
            if (fornecedor == null)
            {
                return null; // Retorna null se o fornecedor não for encontrado
            }

            // Remove o fornecedor do repositório
            _fornecedorRepository.Remove(fornecedor);
            _fornecedorRepository.SaveChanges(); // Persiste as mudanças

            return fornecedor; // Retorna o fornecedor que foi deletado
        }

        public FornecedorEntity? ObterFornecedorPorId(int id)
        {
            // Obtém o fornecedor pelo ID
            return _fornecedorRepository.GetById(id); // Retorna null se não encontrado
        }

        public IEnumerable<FornecedorEntity> ObterTodosFornecedores()
        {
            // Obtém todos os fornecedores
            var fornecedores = _fornecedorRepository.GetAll();
            return fornecedores ?? Enumerable.Empty<FornecedorEntity>(); // Retorna uma coleção vazia se não houver fornecedores
        }
    }
}
