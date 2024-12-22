namespace ToDo.Domain.Primitives;
public abstract class Entity<TKey> : ValueObject
{
    protected Entity(TKey id) => Id = id;
    protected Entity() { }
    public TKey Id { get; init; }
}
