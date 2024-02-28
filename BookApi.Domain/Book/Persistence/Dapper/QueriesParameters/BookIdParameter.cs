using System.ComponentModel;
using BookApi.Domain.Common.Persistence.Dapper.Abstractions;

namespace BookApi.Domain.Book.Persistence.Dapper.QueriesParameters;

public class BookIdParameter : QueryParameter<BookIdParameter>
{
    public Guid? BookId { get; set; }

    BookIdParameter() { }
}
