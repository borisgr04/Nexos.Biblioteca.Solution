using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Base
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GenericRepository<T>() where T : BaseEntity, IAggregateRoot;
        void Commit();
        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
