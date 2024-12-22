using MediatR;
namespace ToDo.Domain.Primitives;

public interface IDomainEvent : INotification
{
    public Guid Id { get; init; }
}
