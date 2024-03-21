namespace Library.Application.Book.Queries.GetByIsbn;

internal sealed record GetByIsbn(in string Isbn) : IQuery<BookView, IResult<BookView>>, IIsbnValidatable;