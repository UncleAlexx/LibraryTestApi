namespace Library.Application.Common.Abstractions.Requests;

public interface ICommand<TRequest, TResponse> : IGeneric<TRequest, TResponse> where TResponse : IResult<TRequest>;