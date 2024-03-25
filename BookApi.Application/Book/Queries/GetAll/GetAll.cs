namespace Library.Application.Book.Queries.GetAll;

internal sealed record GetAll : IEnumerableQuery<BookView, MessageResult<IEnumerable<BookView>>>;