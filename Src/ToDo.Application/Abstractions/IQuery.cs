using MediatR;
using ToDo.Domain.Response;

namespace ToDo.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
