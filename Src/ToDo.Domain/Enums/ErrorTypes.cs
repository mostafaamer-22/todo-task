namespace ToDo.Domain.Enums;

public enum ErrorTypes
    {
        None = 0,
        NotFound,
        Conflict,
        Validation,
        Unauthorized,
        Forbidden,
        BadRequest,
        InternalServerError,
    }

