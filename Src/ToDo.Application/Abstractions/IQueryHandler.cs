using MediatR;
using ToDo.Domain.Response;

namespace ToDo.Application.Abstractions;


public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
