namespace Library.Application.Common.Abstractions.Requests;

public interface IQuery<TRequest, TResponse> : IGeneric<TRequest, TResponse> where TResponse : IResult<TRequest>;