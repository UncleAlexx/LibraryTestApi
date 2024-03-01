namespace Library.Application.Book.Commands.Add;

public sealed class AddHandler(IBookRepository repository) : ICommandHandler<Add, BookView, IResult<BookView>>
{
    private readonly IBookRepository _repository = repository;

    public async Task<IResult<BookView>> Handle(Add request, CancellationToken token)
    {
        var book = BookView.Create(request.Book.Isbn, request.Book.Author, request.Book.Description, request.Book.Genre, 
            request.Book.Title, request.Book.LendingDate, request.Book.ReturnDate, Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());
        BookView addedTEntity = (await _repository.AddAsync(book.Entity))!;
        return addedTEntity is null ? MessageResult<BookView>.Failed(new Addition<BookView, string>("", request.Book.Isbn).Message, 400) :
            MessageResult<BookView>.Success(addedTEntity);
    }
}
