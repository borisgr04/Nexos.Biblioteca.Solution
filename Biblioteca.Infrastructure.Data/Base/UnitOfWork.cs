using Biblioteca.Domain.Base;
using Biblioteca.Infrastructure.Data.Base;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;
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
