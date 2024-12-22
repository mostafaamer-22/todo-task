
using System.Diagnostics.CodeAnalysis;


namespace ToDo.Domain.Response;

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    internal Result(TValue? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        _value = value;
    }

    [NotNull]
    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("Some occurred Errors");

    public static implicit operator Result<TValue>(TValue? value) => Create(value);

    public static implicit operator Result<TValue>(Error error) => Failure<TValue>(error);
}
