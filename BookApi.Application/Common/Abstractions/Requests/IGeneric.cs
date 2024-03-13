namespace Library.Application.Common.Abstractions.Requests;

internal interface ICommand<TRequest, TResponse> : IGeneric<TRequest, TResponse> where TResponse : IResult<TRequest>;