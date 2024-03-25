namespace Library.Application.Book.Commands.Remove;

internal sealed class RemoveHandler(IBookRepository repository) :
    ICommandHandler<Remove, BookView, IResult<BookView>>
{
    private readonly IBookRepository _repository = repository;

    public async Task<IResult<BookView>> Handle(Remove request, CancellationToken token)
    {
        var isbnObj = IsbnObject.Create(request.Isbn).Entity!;
        if (_repository.GetIdByIsbn(isbnObj) == Guid.Empty)
            return MessageResult<BookView>.Failed(new OperationFailedError<BookView>(Operation.Delete, request.Isbn,
            Databases.Library, "Isbn").Message, 404);
        BookView? bookView = await _repository.RemoveAsync(isbnObj);
        return MessageResult<BookView>.Success(bookView!);
    }
}