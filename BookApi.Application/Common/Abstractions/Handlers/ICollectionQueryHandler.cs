namespace Library.Application.Common.Abstractions.Handlers;

internal interface IEnumerableQueryHandler<TQuery, TResponseCollectionType, TResponse> :
    IRequestHandler<TQuery, TResponse> where TQuery : IEnumerableQuery<TResponseCollectionType, TResponse> where TResponse :
    IResult<IEnumerable<TResponseCollectionType>>;