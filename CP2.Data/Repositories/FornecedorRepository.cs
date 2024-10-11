using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP2.Infrastructure.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationContext _context;

        public FornecedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(FornecedorEntity fornecedor)
        {
            if (fornecedor == null) throw new ArgumentNullException(nameof(fornecedor));
            _context.Fornecedores.Add(fornecedor);
        }

        public FornecedorEntity? GetById(int id)
        {
            // Implementando de forma síncrona, se necessário
            return _context.Fornecedores.Find(id);
        }

        public void Update(FornecedorEntity fornecedor)
        {
            if (fornecedor == null) throw new ArgumentNullException(nameof(fornecedor));
            _context.Fornecedores.Update(fornecedor);
        }

        public void Remove(FornecedorEntity fornecedor)
        {
            if (fornecedor == null) throw new ArgumentNullException(nameof(fornecedor));
            _context.Fornecedores.Remove(fornecedor);
        }

        public IEnumerable<FornecedorEntity> GetAll()
        {
            return _context.Fornecedores.ToList(); // Implementando de forma síncrona
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
