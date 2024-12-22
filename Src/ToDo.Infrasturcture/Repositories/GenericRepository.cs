﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToDo.Domain.Primitives;
using ToDo.Domain.Repositories;
using ToDo.Domain.Specification;
using ToDo.Infrasturcture.Context;
using ToDo.Infrasturcture.Specifcation;

namespace ToDo.Infrasturcture.Repositories;

internal class GenericRepository<T> : IGenericRepository<T> where T : ValueObject
{
    private readonly ApplicationDbContext _context;
    protected DbSet<T> _entity;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _entity = context.Set<T>();
    }
    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        => await _entity.AddAsync(entity, cancellationToken);
    public async Task AddRangeAsync(List<T> entities, CancellationToken cancellationToken = default)
        => await _entity.AddRangeAsync(entities, cancellationToken);
    public void Delete(T entity)
        => _entity.Remove(entity);
    public void DeleteRange(IEnumerable<T> entity)
        => _entity.RemoveRange(entity);
    public void Update(T entity)
        => _entity.Update(entity);
    public void UpdateRange(IEnumerable<T> entities)
        => _entity.UpdateRange(entities);
    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _entity.FindAsync(id, cancellationToken);
    public (IQueryable<T> data, int count) GetWithSpec(Specification<T> specifications)
        => SpecificationEvaluator<T>.GetQuery(_entity, specifications);
    public T? GetEntityWithSpec(Specification<T> specifications)
        => SpecificationEvaluator<T>.GetQuery(_entity, specifications).data.FirstOrDefault();
    public async Task<bool> IsExistAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
        => await _entity.AnyAsync(filter, cancellationToken);
    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _context.SaveChangesAsync(cancellationToken) > 0;
    public IReadOnlyList<T  > Get()
        => _entity.AsNoTracking().ToList();

}
