

using ToDo.Domain.Entities;
using ToDo.Domain.Specification;

namespace ToDo.Application.Features.ToDoItem.Query;

internal class GetToDoItemSpecification : Specification<TodoItem>
{
    
    public GetToDoItemSpecification(GetToDoItemQuery request)
    {
        if (request.IsCompleted != null)
            AddCriteria(t => t.IsCompleted == request.IsCompleted);
        ApplyPaging(request.PageSize, request.PageIndex);
    }
}
