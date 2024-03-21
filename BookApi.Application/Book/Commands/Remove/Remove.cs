namespace Library.Application.Book.Commands.Remove;

internal sealed record Remove(in string Isbn) : ICommand<BookView, IResult<BookView>>, IIsbnValidatable;
