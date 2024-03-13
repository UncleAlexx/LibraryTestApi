namespace Library.Application.Book.Queries.GetByIsbn;

internal sealed class GetByIsbnHandler(IBookRepository repository) :
    IQueryHandler<GetByIsbn, BookView, IResult<BookView>>
{
    private readonly IBookRepository _repository = repository;

    public async Task<IResult<BookView>> Handle(GetByIsbn request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIsbnAsync(IsbnObject.Create(request.Isbn).Entity!);
        return entity is null ? MessageResult<BookView>.Failed(new EntityCriteriaNotFoundError<BookView, string>(request.Isbn, nameof(request.Isbn)).Message, 
            404) : MessageResult<BookView>.Success(entity!);
    }
}
