namespace BookApi.Domain.Common.Interfaces;

public interface IMessageResult <T, T2> : IResult<T> where T2 : IMessageResult<T, T2>
{
    public ushort OperationCode { get; init; }
    public string? Message { get; init; }
    public abstract static T2 Success(T instance);
    public abstract static T2 Failed(string message, ushort operationCode);
}