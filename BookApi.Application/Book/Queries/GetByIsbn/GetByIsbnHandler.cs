namespace Library.Application.Book.Queries.GetByIsbn;

internal sealed class GetByIsbnHandler(IBookRepository repository) :
    IQueryHandler<GetByIsbn, BookView, IResult<BookView>>
{
    private readonly IBookRepository _repository = repository;

    public async Task<IResult<BookView>> Handle(GetByIsbn request, CancellationToken cancellationToken)
    {
        var isbn = IsbnObject.Create(request.Isbn);
        var poco = await _repository.GetByIsbnAsync(isbn.Entity!);
        if (poco is null)
            return MessageResult<BookView>.Failed(new EntityCriteriaNotFoundError<BookView, string>(request.Isbn,
                nameof(request.Isbn)).Message, 404);
        var idObj = BookIdObject.Create(poco!.BookId);
        var book = BookView.Create(Stock.Create(isbn, AuthorObject.Create(poco.Author), DescriptionObject.Create(poco.Description!), 
            GenreObject.Create(poco.Genre!), TitleObject.Create(poco.Title), idObj, IdObject.Create(poco.StockId)), 
            Lending.Create(LendingDateObject.Create(poco.LendingDate), ReturnDateObject.Create(poco.ReturnDate), idObj, 
            IdObject.Create(poco.LendingId)), idObj).Entity;
        return MessageResult<BookView>.Success(book!);
    }
}
