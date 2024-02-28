using BookApi.Domain.Common.Errors.Bases;

namespace BookApi.Domain.Common.Errors.ErrorKinds;

public sealed class ViewNotFound<T> : IError
{
    public string? Message { get; init; } = $"No {typeof(T).Name}s found";
}
