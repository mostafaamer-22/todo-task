using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Domain.Enums;
using ToDo.Domain.Response;

namespace ToDo.Api.Controllers;


[ApiController]
[ApiVersion("V1")]
public class ApiController : ControllerBase
{
    protected readonly ISender Sender;

    protected ApiController(ISender sender) => Sender = sender;

    protected IActionResult HandleResult(Result result)
    {
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        else if (result.Error.Type is ErrorTypes.Validation)
        {
            return BadRequest(result);
        }

        return HandleError(result.Error);
    }

    protected IActionResult HandleResult<TValue>(Result<TValue> result)
    {
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        else if (result.Error.Type is ErrorTypes.Validation)
        {
            return BadRequest(result);
        }

        return HandleError(result.Error);
    }

    protected IActionResult HandleError(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorTypes.NotFound => 404,
            ErrorTypes.Conflict => 409,
            ErrorTypes.Validation => 400,
            ErrorTypes.Unauthorized => 401,
            ErrorTypes.Forbidden => 403,
            ErrorTypes.BadRequest => 400,
            ErrorTypes.InternalServerError => 500,
            _ => 500
        };

        return Problem(statusCode: statusCode, title: error.Code, detail: error.Description);
    }
}
