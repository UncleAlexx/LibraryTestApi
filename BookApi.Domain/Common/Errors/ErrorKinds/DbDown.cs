using BookApi.Domain.Common.Enums;
using BookApi.Domain.Common.Errors.Bases;

namespace BookApi.Domain.Common.Errors.ErrorKinds;

public sealed class DbDown(Databases _db) : IError
{
    public string? Message { get; init; } = $"Database {_db} was down";
}
