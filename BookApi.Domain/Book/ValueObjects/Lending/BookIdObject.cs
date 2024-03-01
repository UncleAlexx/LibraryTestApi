namespace Library.Domain.Book.ValueObjects.Lending;

public sealed record BookIdObject : ValueObject<Guid, BookIdObject>
{
    private BookIdObject(Guid value) : base(value) => Value = value;

    public static BookIdObject Create(Guid value) => new(value);

    public static BookIdObject CreateUnique() => new(Guid.NewGuid());
}