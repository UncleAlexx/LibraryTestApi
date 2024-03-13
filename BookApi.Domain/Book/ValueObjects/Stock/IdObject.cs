namespace Library.Domain.Book.ValueObjects.Stock;

public sealed class IdObject : GuidObject<IdObject>
{
    private IdObject(in Guid value) : base(value) { }

    public static new string PropertyName { get; } = "Id";
}