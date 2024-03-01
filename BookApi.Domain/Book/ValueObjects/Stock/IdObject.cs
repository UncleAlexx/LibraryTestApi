namespace Library.Domain.Book.ValueObjects.Stock;

public sealed record IdObject : ValueObject<Guid, IdObject>
{
    private IdObject(Guid value) : base(value) => Value = value;

    public static IdObject Create(Guid value) => new(value);

    public static IdObject CreateUnique() => new(Guid.NewGuid());
}