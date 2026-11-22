namespace Library.Domain.Book.Persistence.Dapper.QueriesParameters;

internal sealed class BookIdParameter : QueryParameter<BookIdParameter, Guid>
{
    public Guid? BookId { get; set; }

    BookIdParameter() { }
}
