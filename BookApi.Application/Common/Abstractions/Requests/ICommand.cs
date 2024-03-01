namespace Library.Application.Common.Abstractions.Requests;

public interface IGeneric<TRequest, TResponse> : IRequest<TResponse> where TResponse : IResult<TRequest>;