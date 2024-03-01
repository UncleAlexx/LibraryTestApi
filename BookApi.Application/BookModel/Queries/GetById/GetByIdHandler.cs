namespace Library.Application.Book.Queries.GetById;

public sealed class GetByIdHandler(IBookRepository repository) : IQueryHandler<GetById, BookView, IResult<BookView>>
{
    private readonly IBookRepository _repository = repository;

    public async Task<IResult<BookView>> Handle(GetById request, CancellationToken token)
    {
        var t = await _repository.GetByIdAsync(IdObject.Create(request.Id));
        return t == default ? MessageResult<BookView>.Failed(new ViewCriteriaNotFound<BookView, Guid>(request.Id).Message, 404) :
            MessageResult<BookView>.Success(t);
    }
}
