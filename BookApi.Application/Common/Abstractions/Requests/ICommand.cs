namespace Library.Application.Common.Abstractions.Requests;

internal interface IGeneric<TRequest, TResponse> : IRequest<TResponse> where TResponse : IResult<TRequest>;