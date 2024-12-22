using ToDo.Application.Abstractions;

namespace ToDo.Application.Features.ToDoItem.Command.MakeToDoItemCompleted;

public record MakeToDoItemCompletedCommand(Guid Id) : ICommand;

