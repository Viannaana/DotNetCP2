using CP2.Domain.Entities;
using CP2.Domain.Interfaces.Dtos;
using System.Collections.Generic;

namespace CP2.Domain.Interfaces
{
    /// <summary>
    /// Interface que define as operações para gerenciar fornecedores.
    /// </summary>
    public interface IFornecedorApplicationService
    {
        /// <summary>
        /// Salva os dados de um fornecedor.
        /// </summary>
        /// <param name="dto">Dados do fornecedor a serem salvos.</param>
        /// <returns>O fornecedor criado.</returns>
        FornecedorEntity? SalvarDadosFornecedor(IFornecedorDto dto);

        /// <summary>
        /// Edita os dados de um fornecedor existente.
        /// </summary>
        /// <param name="id">Identificador do fornecedor a ser editado.</param>
        /// <param name="dto">Dados atualizados do fornecedor.</param>
        /// <returns>O fornecedor atualizado, ou null se não encontrado.</returns>
        FornecedorEntity? EditarDadosFornecedor(int id, IFornecedorDto dto);

        /// <summary>
        /// Deleta um fornecedor existente.
        /// </summary>
        /// <param name="id">Identificador do fornecedor a ser deletado.</param>
        /// <returns>O fornecedor que foi deletado, ou null se não encontrado.</returns>
        FornecedorEntity? DeletarDadosFornecedor(int id);

        /// <summary>
        /// Obtém um fornecedor pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador do fornecedor.</param>
        /// <returns>O fornecedor correspondente, ou null se não encontrado.</returns>
        FornecedorEntity? ObterFornecedorPorId(int id);

        /// <summary>
        /// Obtém todos os fornecedores.
        /// </summary>
        /// <returns>Uma coleção de fornecedores.</returns>
        IEnumerable<FornecedorEntity> ObterTodosFornecedores();
    }
}
