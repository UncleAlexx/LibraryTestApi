namespace Library.Domain.Book.ValueObjects.Lending;

public sealed class BookIdObject : GuidObject<BookIdObject>
{
    private BookIdObject(in Guid value) : base(value) { }

    public static new string PropertyName { get; } = "BookId";
}