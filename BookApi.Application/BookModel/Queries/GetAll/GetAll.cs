namespace Library.Application.Book.Queries.GetAll;

public sealed record GetAll : IEnumerableQuery<BookView, IResult<IEnumerable<BookView>>>;