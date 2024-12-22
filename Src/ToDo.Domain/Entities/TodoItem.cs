
using ToDo.Domain.Primitives;

namespace ToDo.Domain.Entities;

public sealed class TodoItem : AggregateRoot<Guid>, IAuditableEntity
{
    public string Title { get; private set; } = null!;
    public string? Description { get; private set; }
    public bool IsCompleted { get; private set; } = false;
    public DateTime CreatedOnUtc { get; }
    public DateTime? ModifiedOnUtc { get; }

    private TodoItem() { }


    public static TodoItem Create(string title, string description
        , bool isCompleted)
    {
        return new TodoItem()
        {
            Id = new Guid(),
            Title = title,
            Description = description,
            IsCompleted = isCompleted
        };
    }

    public void MakeCompleted()
    {
        IsCompleted = true;    
    }
}
