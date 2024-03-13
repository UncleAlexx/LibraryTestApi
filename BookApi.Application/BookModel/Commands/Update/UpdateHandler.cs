namespace Library.Application.Book.Commands.Update;

internal sealed class UpdateHandler(IBookRepository repository) : ICommandHandler<Update, BookView, IResult<BookView>>
{
    private readonly IBookRepository _repository = repository;

    public async Task<IResult<BookView>> Handle(Update request, CancellationToken token)
    {
        var poco = request.Book;
        var isbn = IsbnObject.Create(poco.Isbn);
        var bookId = BookIdObject.Create(await _repository.GetIdByIsbnAsync(isbn.Entity!));
        var lendingId = IdObject.Create(await _repository.GetLendingIdByIsbnAsync(isbn.Entity!));
        var stockId = IdObject.Create(await _repository.GetStockIdByIsbnAsync(isbn.Entity!));
        var bookEntity = BookView.Create(Stock.Create(isbn, AuthorObject.Create(poco.Author),
            DescriptionObject.Create(poco.Description!), GenreObject.Create(poco.Genre!), TitleObject.Create(poco.Title), bookId,
            stockId), Lending.Create(LendingDateObject.Create(poco.LendingDate),
            ReturnDateObject.Create(poco.ReturnDate), bookId, lendingId), bookId);
        var updated = await _repository.UpdateAsync(bookEntity.Entity!);
        return updated is null ? 
            MessageResult<BookView>.Failed(new OperationFailedError<BookView>(Operation.Update, request.Book.Isbn,
            Databases.Library, "Isbn").Message, 404) : MessageResult<BookView>.Success(updated);
    }
}
