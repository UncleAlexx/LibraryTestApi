namespace Library.Application.Book.Commands.Update;

internal sealed record Update(in BookPoco Book) : ICommand<BookView, IResult<BookView>>, IBookValidatable;
