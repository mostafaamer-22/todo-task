
using ToDo.Application.Abstractions;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using ToDo.Domain.Response;

namespace ToDo.Application.Features.ToDoItem.Command.MakeToDoItemCompleted;

internal class MakeToDoCompletedCommandHandler : ICommandHandler<MakeToDoItemCompletedCommand>
{
    private readonly IGenericRepository<TodoItem> _todoRepo;
    private readonly IUnitOfWork _unitOfWork;

    public MakeToDoCompletedCommandHandler(IGenericRepository<TodoItem> todoRepo
        ,  IUnitOfWork unitOfWork)
    {
        _todoRepo = todoRepo;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(MakeToDoItemCompletedCommand request, CancellationToken cancellationToken)
    {
        var todo = await _todoRepo.GetByIdAsync(request.Id);
        if (todo == null)
            return Error.NotFound();

        todo.MakeCompleted();

         _todoRepo.Update(todo);

        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }
}
