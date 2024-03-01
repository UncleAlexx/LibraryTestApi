namespace Library.Application.Book.Commands.Update;

public sealed record Update(BookPoco Book) : ICommand<BookView, IResult<BookView>>, IBookValidatable;
