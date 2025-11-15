using HexagonalModular.Core.Shared;

public class Result<T>
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public T? Value { get; }
    public IReadOnlyList<Error> Errors { get; }
    public Error? Error => Errors.FirstOrDefault();
    private Result(bool isSuccess, T? value, List<Error> errors)
    {
        IsSuccess = isSuccess;
        Value = value;
        Errors = errors;
    }

    public static Result<T> Success(T value)
        => new Result<T>(true, value, new List<Error>());

    public static Result<T> Failure(Error error)
        => new Result<T>(false, default, new List<Error> { error });

    public static Result<T> Failure(IEnumerable<Error> errors)
        => new Result<T>(false, default, errors.ToList());
}

