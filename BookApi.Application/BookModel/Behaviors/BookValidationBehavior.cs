namespace Library.Application.BookModel.Behaviors;

public class BookValidationBehavior<TRequest, TResponse>(IValidator<BookView> validator) : IPipelineBehavior<TRequest, IResult<BookView>> where TRequest :
    IBookValidatable
{
    private readonly IValidator<BookView> _validator = validator;

    public async Task<IResult<BookView>> Handle(TRequest request, RequestHandlerDelegate<IResult<BookView>> next, CancellationToken cancellationToken)
    {
        var book = BookView.Create(request.Book.Isbn, request.Book.Author, request.Book.Description, request.Book.Genre, request.Book.Title,
         request.Book.LendingDate, request.Book.ReturnDate, Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());
        var a = await(await _validator.ValidateAsync(book.Entity)).FailValidationIfInvalidAsync(next);
        return a;
    }
}
