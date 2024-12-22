

namespace ToDo.Domain.Response;

public interface IValidationResult
{
    string[] PropertyNames { get; }
    string[] ErrorMessages { get; }
}