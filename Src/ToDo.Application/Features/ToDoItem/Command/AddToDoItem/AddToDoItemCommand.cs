
using AutoMapper;
using ToDo.Application.Abstractions;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.ToDoItem.Command.AddToDoItem;

public sealed record AddToDoItemCommand(string title , string description , bool isCompleted) : ICommand<Guid>;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddToDoItemCommand, TodoItem>()
            .ReverseMap();
    }
}