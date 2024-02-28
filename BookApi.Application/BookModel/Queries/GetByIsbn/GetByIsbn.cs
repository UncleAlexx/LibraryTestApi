namespace BookApi.Application.Book.Queries.GetByIsbn;

public sealed record GetByIsbn(string Isbn) : IQuery<BookView, IResult<BookView>>, IIsbnValidatable;