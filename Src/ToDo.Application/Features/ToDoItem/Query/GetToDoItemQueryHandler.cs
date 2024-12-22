using AutoMapper;
using ToDo.Application.Abstractions;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using ToDo.Domain.Response;

namespace ToDo.Application.Features.ToDoItem.Query;

internal class GetToDoItemQueryHandler : IQueryHandler<GetToDoItemQuery, Pagination<GetToDoItemQueryResponse>>
{
    private readonly IGenericRepository<TodoItem> _toDoRepo;
    private readonly IMapper _mapper;

    public GetToDoItemQueryHandler(IGenericRepository<TodoItem> toDoRepo
        , IMapper mapper)
    {
        _toDoRepo = toDoRepo;
        _mapper = mapper;
    }
    public Task<Result<Pagination<GetToDoItemQueryResponse>>> Handle(GetToDoItemQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetToDoItemSpecification(request);

        (var response, var count) = _toDoRepo.GetWithSpec(spec);

        var data = _mapper.Map<IReadOnlyList<GetToDoItemQueryResponse>>(response);

        var result = Pagination<GetToDoItemQueryResponse>.Success(request.PageIndex , 
             request.PageSize ,
            count ,
            data);

        return Task.FromResult(Result.Success(result));    
    }
}
