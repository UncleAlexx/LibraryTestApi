namespace Library.Application.Book.Queries.GetById;

internal sealed record GetById(in Guid Id) : IQuery<BookView, IResult<BookView>>, IIdValidatable;