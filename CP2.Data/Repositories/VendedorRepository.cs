using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CP2.Infrastructure.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly ApplicationContext _context;

        public VendedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(VendedorEntity vendedor)
        {
            if (vendedor == null) throw new ArgumentNullException(nameof(vendedor));
            _context.Vendedores.Add(vendedor);
            SaveChanges(); // Salva as mudanças
        }

        public void Update(VendedorEntity vendedor)
        {
            if (vendedor == null) throw new ArgumentNullException(nameof(vendedor));
            _context.Vendedores.Update(vendedor);
            SaveChanges(); // Salva as mudanças
        }

        public void Remove(int id) // Método ajustado para receber um ID
        {
            var vendedor = _context.Vendedores.Find(id);
            if (vendedor != null)
            {
                _context.Vendedores.Remove(vendedor);
                SaveChanges(); // Salva as mudanças
            }
        }

        public VendedorEntity? GetById(int id)
        {
            return _context.Vendedores.Find(id);
        }

        public IEnumerable<VendedorEntity> GetAll()
        {
            return _context.Vendedores.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        // Método assíncrono para salvar mudanças
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        // Método assíncrono para obter vendedor por ID
        public async Task<VendedorEntity?> GetByIdAsync(int id)
        {
            return await _context.Vendedores.FindAsync(id);
        }

        // Método assíncrono para obter todos os vendedores
        public async Task<IEnumerable<VendedorEntity>> GetAllAsync()
        {
            return await _context.Vendedores.ToListAsync();
        }
    }
}
