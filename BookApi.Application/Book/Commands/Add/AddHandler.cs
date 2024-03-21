namespace Library.Application.Book.Commands.Add;

internal sealed class AddHandler(IBookRepository repository) : ICommandHandler<Add, BookView, IResult<BookView>>
{
    private readonly IBookRepository _repository = repository;

    public async Task<IResult<BookView>> Handle(Add request, CancellationToken token)
    {
        var poco = request.Book;
        var bookId = BookIdObject.CreateUnique();
        var book = BookView.Create(Stock.Create(IsbnObject.Create(poco.Isbn), AuthorObject.Create(poco.Author),
            DescriptionObject.Create(poco.Description!), GenreObject.Create(poco.Genre!), TitleObject.Create(poco.Title), bookId,
            IdObject.CreateUnique()), Lending.Create(LendingDateObject.Create(poco.LendingDate),
            ReturnDateObject.Create(poco.ReturnDate), bookId, IdObject.CreateUnique()), bookId);
        BookView addedTEntity = (await _repository.AddAsync(book.Entity!))!;
        return addedTEntity is null ? MessageResult<BookView>.Failed(new InsertionError<BookView, string>(request.Book.Isbn, "Isbn").
            Message, 400): MessageResult<BookView>.Success(addedTEntity);
    }
}
