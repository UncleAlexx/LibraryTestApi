namespace Library.Application.Book.Behaviors;

internal sealed class BookValidationBehavior<TRequest, TResponse>(IValidator<BookView> validator) : 
    IPipelineBehavior<TRequest, IResult<BookView>> where TRequest : IBookValidatable
{
    private readonly IValidator<BookView> _validator = validator;

    public async Task<IResult<BookView>> Handle(TRequest request, 
        RequestHandlerDelegate<IResult<BookView>> next, CancellationToken cancellationToken)
    {
        var poco = request.Book;
        var bookId = BookIdObject.Create(poco.BookId);
        var bookEntity = BookView.Create(Stock.Create(IsbnObject.Create(poco.Isbn), AuthorObject.Create(poco.Author),
            DescriptionObject.Create(poco.Description!), GenreObject.Create(poco!.Genre!), TitleObject.Create(poco.Title), bookId, 
            IdObject.Create(poco.StockId)), Lending.Create(LendingDateObject.Create(poco.LendingDate), 
            ReturnDateObject.Create(poco.ReturnDate), bookId, IdObject.Create(poco.LendingId)), bookId);
        var validationResult = await(await _validator.ValidateAsync(bookEntity?.Entity!)).FailValidationIfInvalidAsync(next);
        return validationResult;
    }
}
