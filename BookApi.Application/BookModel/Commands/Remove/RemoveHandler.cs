namespace Library.Application.Book.Commands.Remove;

internal sealed class RemoveHandler(IBookRepository repository) :
    ICommandHandler<Remove, BookView, IResult<BookView>>
{
    private readonly IBookRepository _repository = repository;

    public async Task<IResult<BookView>> Handle(Remove request, CancellationToken token)
    {
        BookView? bookView = await _repository.RemoveAsync(IsbnObject.Create(request.Isbn).Entity!);
        return bookView is null ?
            MessageResult<BookView>.Failed(new OperationFailedError<BookView>(Operation.Update, request.Isbn,
            Databases.Library, "Isbn").Message, 404) : MessageResult<BookView>.Success(bookView);
    }
}