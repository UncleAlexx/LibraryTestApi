namespace Library.Domain.Common.Errors.ErrorKinds;

public sealed class DbDownError(in Databases db) : IError
{
    public string Message { get; init; } = $"Database {db} was down";
}
