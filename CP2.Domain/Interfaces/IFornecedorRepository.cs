using CP2.Domain.Entities;
using System.Collections.Generic;

namespace CP2.Domain.Interfaces
{
    /// <summary>
    /// Interface que define as operações de repositório para gerenciar fornecedores.
    /// </summary>
    public interface IFornecedorRepository
    {
        /// <summary>
        /// Adiciona um novo fornecedor ao repositório.
        /// </summary>
        /// <param name="fornecedor">O fornecedor a ser adicionado.</param>
        void Add(FornecedorEntity fornecedor);

        /// <summary>
        /// Obtém um fornecedor pelo seu identificador.
        /// </summary>
        /// <param name="id">O identificador do fornecedor.</param>
        /// <returns>O fornecedor correspondente, ou null se não encontrado.</returns>
        FornecedorEntity? GetById(int id);

        /// <summary>
        /// Atualiza os dados de um fornecedor existente.
        /// </summary>
        /// <param name="fornecedor">O fornecedor com os dados atualizados.</param>
        void Update(FornecedorEntity fornecedor);

        /// <summary>
        /// Remove um fornecedor do repositório.
        /// </summary>
        /// <param name="fornecedor">O fornecedor a ser removido.</param>
        void Remove(FornecedorEntity fornecedor);

        /// <summary>
        /// Obtém todos os fornecedores.
        /// </summary>
        /// <returns>Uma coleção de todos os fornecedores.</returns>
        IEnumerable<FornecedorEntity> GetAll();

        /// <summary>
        /// Salva as alterações feitas no repositório.
        /// </summary>
        void SaveChanges();
    }
}
