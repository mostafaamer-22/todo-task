using System.Collections;

using ToDo.Domain.Primitives;
using ToDo.Domain.Repositories;
using ToDo.Infrasturcture.Context;
using ToDo.Infrasturcture.Repositories;

namespace ToDo.Infrasturcture;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private Hashtable _repositories = new();

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IGenericRepository<T> Repository<T>() where T : ValueObject
    {
        if (_repositories is null)
            _repositories = new Hashtable();

        var type = typeof(T).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repository = new GenericRepository<T>(_context);
            _repositories.Add(type, repository);
        }

        return (IGenericRepository<T>)_repositories[type]!;
    }

    public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
        => await _context.SaveChangesAsync(cancellationToken);
}
