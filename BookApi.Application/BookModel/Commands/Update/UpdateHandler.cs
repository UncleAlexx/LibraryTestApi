using BookApi.Application.Common.Abstractions.Handlers;
namespace BookApi.Application.Book.Commands.Update;

public sealed class UpdateHandler(IBookRepository repository) : ICommandHandler<Update, BookView, IResult<BookView>>
{
    private readonly IBookRepository _repository = repository;

    public async Task<IResult<BookView>> Handle(Update request, CancellationToken token)
    {
        BookView? updated = BookView.Create(request.Book.Isbn, request.Book.Author, request.Book.Description, request.Book.Genre, request.Book.Title,
            request.Book.LendingDate, request.Book.ReturnDate, Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()).Entity;
        updated = (await _repository.UpdateAsync(updated))!;
        return updated is null ? 
            MessageResult<BookView>.Failed(new OperationFailed<BookView>(Operation.Update, request.Book.Isbn, Databases.Library).
            Message, 404) : MessageResult<BookView>.Success(updated);
    }
}
