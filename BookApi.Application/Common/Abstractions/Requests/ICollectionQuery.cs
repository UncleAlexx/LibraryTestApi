namespace Library.Application.Common.Abstractions.Requests;

internal interface IEnumerableQuery<TRequest, TResponse> : IRequest<TResponse> where TResponse : IResult<IEnumerable<TRequest>>;