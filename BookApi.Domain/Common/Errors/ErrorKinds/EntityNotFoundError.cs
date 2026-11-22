namespace Library.Domain.Common.Errors.ErrorKinds;

public sealed class EntityNotFoundError<TEntity> : IError
{
    public string Message { get; init; } = $"No {typeof(TEntity).Name}s found";
}
