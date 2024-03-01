namespace Library.Application.Book.Commands.Add;

public sealed record Add(BookPoco Book) : ICommand<BookView, IResult<BookView>>, IBookValidatable;
