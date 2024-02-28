using BookApi.Domain.Common.Models;
using BookApi.Domain.Common.Results.ResultsKind;

namespace BookApi.Domain.Book.ValueObjects.Stock;

public record IdObject : ValueObject<Guid, IdObject>
{
    private IdObject(Guid value) : base(value) => Value = value;

    public static IdObject Create(Guid value) => new(value);

    public static IdObject CreateUnique() => new(Guid.NewGuid());
}