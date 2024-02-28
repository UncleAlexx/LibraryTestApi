using BookApi.Domain.Common.Interfaces;

namespace BookApi.Application.Book.Queries.GetAll;

public sealed class GetAllHandler(IBookRepository repository) :
    IEnumerableQueryHandler<GetAll, BookView, IResult<IEnumerable<BookView>>>
{
    private readonly IBookRepository _repository = repository;

    public async Task<IResult<IEnumerable<BookView>>> Handle(GetAll request, CancellationToken token)
    {

        return await ValidationResultExtensions.FailDbExceptionIfErrorAsync<GetAll, IEnumerable<BookView>>(async () =>
        {
            var all = await _repository.GetAllAsync();
            return all.Any() ? MessageResult<IEnumerable<BookView>>.Success(all) :
                MessageResult<IEnumerable<BookView>>.Failed(new ViewNotFound<BookView>().Message, 404);
        });
    }
}
