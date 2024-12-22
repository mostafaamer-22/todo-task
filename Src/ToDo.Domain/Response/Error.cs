

using ToDo.Domain.Enums;
using ToDo.Domain.Resources;

namespace ToDo.Domain.Response;

public record Error(string Code, ErrorTypes Type, string Description = "")
{
    public static readonly Error None = new(Message.Application_Success, ErrorTypes.None);

    public static Error CreateError(ErrorTypes errorType, string code)
    {
        return new Error(code, errorType);
    }

    public static Error NotFound() =>
        new Error(Message.Application_NotFound, ErrorTypes.NotFound);

    public static Error Conflict() =>
        new Error(Message.Application_Conflict, ErrorTypes.Conflict);

    public static Error Validation() =>
        new Error(Message.Application_Validation, ErrorTypes.Validation);

    public static Error Unauthorized() =>
        new Error(Message.Application_Unauthorized, ErrorTypes.Unauthorized);

    public static Error Forbidden() =>
        new Error(Message.Application_Forbidden, ErrorTypes.Forbidden);

    public static Error BadRequest() =>
        new Error(Message.Application_BadRequest, ErrorTypes.BadRequest);

    public static Error InternalServerError() =>
        new Error(Message.Application_InternalServerError, ErrorTypes.InternalServerError);

}
