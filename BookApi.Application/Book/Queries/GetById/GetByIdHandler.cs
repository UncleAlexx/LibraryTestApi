namespace Library.Application.Book.Queries.GetById;

internal sealed class GetByIdHandler(IBookRepository repository) : IQueryHandler<GetById, BookView, IResult<BookView>>
{
    private readonly IBookRepository _repository = repository;

    public async Task<IResult<BookView>> Handle(GetById request, CancellationToken token)
    {
        var idObj = BookIdObject.Create(request.Id);
        var poco = await _repository.GetByIdAsync(idObj);
        if (poco is null)
            return MessageResult<BookView>.Failed(new EntityCriteriaNotFoundError<BookView, Guid>(request.Id, nameof(request.Id)).
                Message, 404);
        var book = BookView.Create(Stock.Create(IsbnObject.Create(poco!.Isbn), AuthorObject.Create(poco.Author),
            DescriptionObject.Create(poco.Description!), GenreObject.Create(poco.Genre!), TitleObject.Create(poco.Title), idObj,
            IdObject.Create(poco.StockId)), Lending.Create(LendingDateObject.Create(poco.LendingDate),
            ReturnDateObject.Create(poco.ReturnDate), idObj, IdObject.Create(poco.LendingId)), idObj).Entity;
        return MessageResult<BookView>.Success(book!);
    }
}
