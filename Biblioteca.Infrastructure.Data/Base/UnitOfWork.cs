using Biblioteca.Core.Domain.Contracts;
using Biblioteca.Domain.Base;
using Biblioteca.Infrastructure.Data.Base;
using Biblioteca.Infrastructure.Data.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;

        private ILibroRepository _libroRepository;
        public ILibroRepository LibroRepository 
        {
            get { return _libroRepository ?? (_libroRepository = new LibroRepository(_context)); } 
        }
        
        private IEditorialRepository _editorialRepository;
        public IEditorialRepository EditorialRepository
        {
            get { return _editorialRepository ?? (_editorialRepository = new EditorialRepository(_context)); }
        }

        public UnitOfWork(IDbContext context) => _context = context;

        public IGenericRepository<T> GenericRepository<T>() where T : BaseEntity, IAggregateRoot
        {
            return new GenericRepository<T>(_context);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

       

      
    }
}
