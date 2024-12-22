
using ToDo.Application.Abstractions;
using ToDo.Domain.Response;

namespace ToDo.Application.Features.ToDoItem.Query;

public record GetToDoItemQuery : IQuery<Pagination<GetToDoItemQueryResponse>>
{
    public int PageSize { get; set; } = 10;
    public int PageIndex { get; set; } = 1;
    public bool? IsCompleted { get; set; }
}

