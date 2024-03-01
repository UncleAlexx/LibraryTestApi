namespace Library.Application.Book.Commands.Remove;

public sealed record Remove(string Isbn) : ICommand<BookView, IResult<BookView>>, IIsbnValidatable;
