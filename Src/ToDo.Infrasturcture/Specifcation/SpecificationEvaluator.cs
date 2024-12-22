using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Primitives;
using ToDo.Domain.Specification;

namespace ToDo.Infrasturcture.Specifcation;

public static class SpecificationEvaluator<T> where T : ValueObject
{
    public static (IQueryable<T> data, int count) GetQuery(
        IQueryable<T> inputQuery,
        Specification<T> specifications)
    {
        IQueryable<T> queryable = inputQuery;

        if (specifications.IsGlobalFiltersIgnored)
            queryable = queryable.IgnoreQueryFilters();

        if (specifications.Criteria is not null)
            queryable = queryable.Where(specifications.Criteria);

        if (specifications.OrderByDescendingExpression.Any())
        {
            IOrderedQueryable<T>? orderedQuery = null;

            foreach (var orderByDesc in specifications.OrderByDescendingExpression)
                orderedQuery = orderedQuery is null
                    ? queryable.OrderByDescending(orderByDesc)
                    : orderedQuery.ThenByDescending(orderByDesc);

            queryable = orderedQuery!;
        }
        else if (specifications.OrderByExpression.Any())
        {
            IOrderedQueryable<T>? orderedQuery = null;

            foreach (var orderBy in specifications.OrderByExpression)
                orderedQuery = orderedQuery is null
                    ? queryable.OrderBy(orderBy)
                    : orderedQuery.ThenBy(orderBy);

            queryable = orderedQuery!;
        }

        if (specifications.IsDistinct)
            queryable = queryable.Distinct();

        int count = specifications.IsTotalCountEnable ? queryable.Count() : 0;

        if (specifications.IsPagingEnabled)
            queryable = queryable.Skip(specifications.Skip).Take(specifications.Take);

        foreach (var include in specifications.Includes)
            queryable = queryable.Include(include);

        return (queryable, count);
    }
}
