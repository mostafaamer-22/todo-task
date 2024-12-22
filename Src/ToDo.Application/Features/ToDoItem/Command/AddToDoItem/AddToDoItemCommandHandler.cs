using AutoMapper;
using ToDo.Application.Abstractions;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using ToDo.Domain.Response;

namespace ToDo.Application.Features.ToDoItem.Command.AddToDoItem;

public class AddToDoItemCommandHandler : ICommandHandler<AddToDoItemCommand, Guid>
{
    private readonly IGenericRepository<TodoItem> _todoRepo;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AddToDoItemCommandHandler(IGenericRepository<TodoItem> todoRepo
        , IMapper mapper , IUnitOfWork unitOfWork)
    {
        _todoRepo = todoRepo;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(AddToDoItemCommand request, CancellationToken cancellationToken)
    {
        var todoItem =  _mapper.Map<TodoItem>(request);
        await _todoRepo.AddAsync(todoItem , cancellationToken);
        await  _unitOfWork.SaveAsync(cancellationToken);
        return Result.Success(todoItem.Id);
    }
}
