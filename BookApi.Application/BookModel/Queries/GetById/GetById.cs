namespace Library.Application.Book.Queries.GetById;

public sealed record GetById(Guid Id) : IQuery<BookView, IResult<BookView>>, IIdValidatable;