using AutoMapper;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.ToDoItem.Query;

public class GetToDoItemQueryResponse
{
    public Guid Id { get; set; }
    public string Title { get; init; }
    public string? Description { get; init; }
    public bool IsCompleted { get; init; }
    public DateTime CreatedOnUtc { get; init; }
    public DateTime? ModifiedOnUtc { get; init; }
}

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetToDoItemQueryResponse, TodoItem>()
            .ReverseMap();


    }
}
