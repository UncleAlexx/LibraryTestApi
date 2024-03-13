namespace Library.Application.Common.Abstractions.Requests;

internal interface IQuery<TRequest, TResponse> : IGeneric<TRequest, TResponse> where TResponse : IResult<TRequest>;