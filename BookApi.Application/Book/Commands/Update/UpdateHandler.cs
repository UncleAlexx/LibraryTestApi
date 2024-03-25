namespace Library.Application.Book.Commands.Update;

internal sealed class UpdateHandler(IBookRepository repository) : ICommandHandler<Update, BookView, IResult<BookView>>
{
    private readonly IBookRepository _repository = repository;

    public Task<IResult<BookView>> Handle(Update request, CancellationToken token)
    {
        var poco = request.Book;
        var isbn = IsbnObject.Create(poco.Isbn); 
        if (_repository.GetIdByIsbn(isbn.Entity!) == Guid.Empty)
            return Task.FromResult<IResult<BookView>>(MessageResult<BookView>.Failed(new OperationFailedError<BookView>(Operation.Update,
                request.Book.Isbn, Databases.Library, "Isbn").Message, 404));
        var bookId = BookIdObject.Create(_repository.GetIdByIsbn(isbn.Entity!));
        var lendingId = IdObject.Create(_repository.GetLendingIdByIsbn(isbn.Entity!));
        var stockId = IdObject.Create(_repository.GetStockIdByIsbn(isbn.Entity!));
        var bookEntity = BookView.Create(Stock.Create(isbn, AuthorObject.Create(poco.Author),
            DescriptionObject.Create(poco.Description!), GenreObject.Create(poco.Genre!), TitleObject.Create(poco.Title), bookId,
            stockId), Lending.Create(LendingDateObject.Create(poco.LendingDate),
            ReturnDateObject.Create(poco.ReturnDate), bookId, lendingId), bookId);
        var updated = _repository.Update(bookEntity.Entity!);
        return Task.FromResult<IResult<BookView>>(MessageResult<BookView>.Success(updated!));
    }
}
