namespace Library.Application.Book.Queries.GetById;

internal sealed class GetByIdHandler(IBookRepository repository) : IQueryHandler<GetById, BookView, IResult<BookView>>
{
    private readonly IBookRepository _repository = repository;

    public async Task<IResult<BookView>> Handle(GetById request, CancellationToken token)
    {
        var entity = await _repository.GetByIdAsync(BookIdObject.Create(request.Id));
        return entity is null ? MessageResult<BookView>.Failed(new EntityCriteriaNotFoundError<BookView, Guid>(request.Id, nameof(request.Id)).Message, 404) :
            MessageResult<BookView>.Success(entity);
    }
}
