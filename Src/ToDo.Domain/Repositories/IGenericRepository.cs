
using System.Linq.Expressions;

using ToDo.Domain.Primitives;
using ToDo.Domain.Specification;

namespace ToDo.Domain.Repositories;

public interface IGenericRepository<T> where T : ValueObject
{
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    Task AddRangeAsync(List<T> entities, CancellationToken cancellationToken = default);
    IReadOnlyList<T> Get();
    (IQueryable<T> data, int count) GetWithSpec(Specification<T> specification);
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    T? GetEntityWithSpec(Specification<T> specification);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    void Delete(T entity);
    void DeleteRange(IEnumerable<T> entity);
    Task<bool> IsExistAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
}
