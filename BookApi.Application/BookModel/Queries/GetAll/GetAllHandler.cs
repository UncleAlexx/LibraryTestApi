namespace Library.Application.Book.Queries.GetAll;

internal sealed class GetAllHandler(IBookRepository repository) :
    IEnumerableQueryHandler<GetAll, BookView, MessageResult<IEnumerable<BookView>>>
{
    private readonly IBookRepository _repository = repository;
    public async Task<MessageResult<IEnumerable<BookView>>> Handle(GetAll request, CancellationToken cancellationToken)
    {
        return await ValidationResultExtensions.FailDbExceptionIfErrorAsync<GetAll, IEnumerable<BookView>>(async () =>
        {
            var all = await _repository.GetAllAsync();
            return all.Any() ? MessageResult<IEnumerable<BookView>>.Success(all) :
                MessageResult<IEnumerable<BookView>>.Failed(new EntityNotFoundError<BookView>().Message, 404);
        });
    }
}
