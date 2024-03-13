namespace Library.Application.Book.Commands.Add;

internal sealed record Add(in BookPoco Book) : ICommand<BookView, IResult<BookView>>, IBookValidatable;
