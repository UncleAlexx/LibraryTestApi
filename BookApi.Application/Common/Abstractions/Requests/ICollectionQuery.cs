namespace BookApi.Application.Common.Abstractions.Requests;

public interface IEnumerableQuery<TRequest, TResponse> : IRequest<TResponse> where TResponse : IResult<IEnumerable<TRequest>>
{
}