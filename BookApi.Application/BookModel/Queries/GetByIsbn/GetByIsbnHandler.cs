namespace Library.Application.Book.Queries.GetByIsbn;

public sealed class GetByIsbnHandler(IBookRepository repository) :
    IQueryHandler<GetByIsbn, BookView, IResult<BookView>>
{
    private readonly IBookRepository _repository = repository;

    public async Task<IResult<BookView>> Handle(GetByIsbn request, CancellationToken cancellationToken)
    {
        var t = await _repository.GetByIsbnAsync(IsbnObject.Create(request.Isbn).Entity);
        return t == default ? MessageResult<BookView>.Failed(new ViewCriteriaNotFound<BookView, string>(request.Isbn).Message, 404) :
            MessageResult<BookView>.Success(t);
    }
}
