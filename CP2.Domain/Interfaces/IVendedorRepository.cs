using CP2.Domain.Entities;
using System.Collections.Generic;

namespace CP2.Domain.Interfaces
{
    /// <summary>
    /// Interface que define as operações de repositório para gerenciar vendedores.
    /// </summary>
    public interface IVendedorRepository
    {
        /// <summary>
        /// Adiciona um novo vendedor.
        /// </summary>
        /// <param name="vendedor">O vendedor a ser adicionado.</param>
        void Add(VendedorEntity vendedor);

        /// <summary>
        /// Atualiza os dados de um vendedor existente.
        /// </summary>
        /// <param name="vendedor">O vendedor com dados atualizados.</param>
        void Update(VendedorEntity vendedor);

        /// <summary>
        /// Remove um vendedor pelo seu identificador.
        /// </summary>
        /// <param name="id">O identificador do vendedor a ser removido.</param>
        void Remove(int id);

        /// <summary>
        /// Obtém um vendedor pelo seu identificador.
        /// </summary>
        /// <param name="id">O identificador do vendedor.</param>
        /// <returns>O vendedor correspondente, ou null se não encontrado.</returns>
        VendedorEntity? GetById(int id);

        /// <summary>
        /// Obtém todos os vendedores.
        /// </summary>
        /// <returns>Uma coleção de todos os vendedores.</returns>
        IEnumerable<VendedorEntity> GetAll();

        /// <summary>
        /// Salva as mudanças feitas no repositório.
        /// </summary>
        void SaveChanges();
    }
}
