using LinqKit;
using System.Linq.Expressions;

namespace ToDo.Domain.Specification;

public abstract class Specification<T> where T : class
{
    public Expression<Func<T, bool>> Criteria { get; private set; } = entity => true;
    public IReadOnlyList<string> Includes => _includes.AsReadOnly();
    public IReadOnlyList<Expression<Func<T, object>>> OrderByExpression => _orderByExpression.AsReadOnly();
    public IReadOnlyList<Expression<Func<T, object>>> OrderByDescendingExpression => _orderByDescendingExpression.AsReadOnly();

    private readonly List<string> _includes = new();
    private readonly List<Expression<Func<T, object>>> _orderByExpression = new();
    private readonly List<Expression<Func<T, object>>> _orderByDescendingExpression = new();

    public int Take { get; private set; }
    public int Skip { get; private set; }
    public bool IsPagingEnabled { get; private set; }
    public bool IsTotalCountEnable { get; private set; }
    public bool IsDistinct { get; private set; }
    public bool IsGlobalFiltersIgnored { get; private set; }
    public bool IsSplitQuery { get; private set; }

    protected Specification(bool splitQuery = false)
    {
        IsSplitQuery = splitQuery;
    }

    protected Specification<T> AddInclude(string includeExpression)
    {
        if (string.IsNullOrWhiteSpace(includeExpression))
            throw new ArgumentException("Include expression cannot be null or empty.", nameof(includeExpression));
        _includes.Add(includeExpression);
        return this;
    }

    protected Specification<T> AddCriteria(Expression<Func<T, bool>> criteriaExpression)
    {
        Criteria = Criteria.And(criteriaExpression);
        return this;
    }

    protected Specification<T> AddOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        if (orderByExpression is null)
            throw new ArgumentException("orderby expression cannot be null or empty.", nameof(orderByExpression));
        _orderByExpression.Add(orderByExpression);
        return this;
    }

    protected Specification<T> AddOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
    {
        if (orderByDescendingExpression is null)
            throw new ArgumentException("orderby descending expression cannot be null or empty.", nameof(orderByDescendingExpression));
        _orderByDescendingExpression.Add(orderByDescendingExpression);
        return this;
    }

    protected Specification<T> ApplyPaging(int pageSize, int pageIndex)
    {
        if (pageSize <= 0) throw new ArgumentOutOfRangeException(nameof(pageSize));
        if (pageIndex <= 0) throw new ArgumentOutOfRangeException(nameof(pageIndex));

        Skip = pageSize * (pageIndex - 1);
        Take = pageSize;
        IsPagingEnabled = true;
        EnableTotalCount();
        return this;
    }

    protected void EnableTotalCount() => IsTotalCountEnable = true;
    protected void EnableDistinct() => IsDistinct = true;
    protected void IgnoreGlobalFilters() => IsGlobalFiltersIgnored = true;
}
