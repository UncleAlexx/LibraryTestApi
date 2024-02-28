namespace BookApi.Application.Common.Abstractions.Handlers;

public interface IEnumerableQueryHandler<TQuery, TResponseCollectionType, TResponse> :
    IRequestHandler<TQuery, TResponse> where TQuery : IEnumerableQuery<TResponseCollectionType, TResponse> where TResponse :
    IResult<IEnumerable<TResponseCollectionType>>
{
}
