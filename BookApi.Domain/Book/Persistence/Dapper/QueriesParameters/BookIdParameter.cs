namespace Library.Domain.Book.Persistence.Dapper.QueriesParameters;

public sealed class BookIdParameter : QueryParameter<BookIdParameter>
{
    public Guid? BookId { get; set; }

    BookIdParameter() { }
}
