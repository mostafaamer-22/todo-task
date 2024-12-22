
using ToDo.Domain.Primitives;

namespace ToDo.Domain.Repositories;

public interface IUnitOfWork
{
    Task<int> SaveAsync(CancellationToken cancellationToken = default);
    IGenericRepository<T> Repository<T>() where T : ValueObject;
}
