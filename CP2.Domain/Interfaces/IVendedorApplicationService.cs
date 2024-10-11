using CP2.Domain.Interfaces.Dtos;
using CP2.Domain.Entities;
using System.Collections.Generic;

namespace CP2.Domain.Interfaces
{
    /// <summary>
    /// Interface que define as operações de serviço para gerenciar vendedores.
    /// </summary>
    public interface IVendedorApplicationService
    {
        /// <summary>
        /// Salva os dados de um vendedor.
        /// </summary>
        /// <param name="vendedorDto">Os dados do vendedor a serem salvos.</param>
        void SalvarDadosVendedor(IVendedorDto vendedorDto);

        /// <summary>
        /// Deleta um vendedor pelo seu identificador.
        /// </summary>
        /// <param name="id">O identificador do vendedor a ser deletado.</param>
        void DeletarDadosVendedor(int id);

        /// <summary>
        /// Obtém todos os vendedores.
        /// </summary>
        /// <returns>Uma coleção de todos os vendedores.</returns>
        IEnumerable<VendedorEntity> ObterTodosVendedores();

        /// <summary>
        /// Obtém um vendedor pelo seu identificador.
        /// </summary>
        /// <param name="id">O identificador do vendedor.</param>
        /// <returns>O vendedor correspondente, ou null se não encontrado.</returns>
        VendedorEntity? ObterVendedorPorId(int id);

        /// <summary>
        /// Edita os dados de um vendedor existente.
        /// </summary>
        /// <param name="id">O identificador do vendedor a ser editado.</param>
        /// <param name="vendedorDto">Os dados atualizados do vendedor.</param>
        void EditarDadosVendedor(int id, IVendedorDto vendedorDto);
    }
}
