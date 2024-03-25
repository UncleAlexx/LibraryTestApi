namespace Library.Application.Book.Commands.Add;

internal sealed class AddHandler(IBookRepository repository) : ICommandHandler<Add, BookView, IResult<BookView>>
{
    private readonly IBookRepository _repository = repository;

    public async Task<IResult<BookView>> Handle(Add request, CancellationToken token)
    {
        var poco = request.Book;
        var isbnObj = IsbnObject.Create(request.Book.Isbn);
        if (_repository.GetIdByIsbn(isbnObj.Entity!) != Guid.Empty)
            return MessageResult<BookView>.Failed(new InsertionError<BookView, string>(request.Book.Isbn, "Isbn").Message, 400);
        var bookId = BookIdObject.CreateUnique();
        var book = BookView.Create(Stock.Create(isbnObj, AuthorObject.Create(poco.Author),
            DescriptionObject.Create(poco.Description!), GenreObject.Create(poco.Genre!), TitleObject.Create(poco.Title), bookId,
            IdObject.CreateUnique()), Lending.Create(LendingDateObject.Create(poco.LendingDate),
            ReturnDateObject.Create(poco.ReturnDate), bookId, IdObject.CreateUnique()), bookId);
        BookView addedTEntity = (await _repository.AddAsync(book.Entity!))!;
        return MessageResult<BookView>.Success(addedTEntity);
    }
}
