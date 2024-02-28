using BookApi.Domain.Common.Interfaces;

namespace BookApi.Domain.Common.Results.ResultsKind;

public  class MessageResult<T> : ResultBase<T>, IMessageResult<T, MessageResult<T>>
{
    private MessageResult(T entity) : base(true) => Entity = entity;

    private MessageResult(string message, ushort operationCode) : base(false) => (Message, OperationCode) = (message, operationCode);

    public string? Message { get; init; }

    public ushort OperationCode { get; init; } = 200;

    public static MessageResult<T> Success(T entity) => new(entity);

    public static MessageResult<T> Failed(string message, ushort operationCode) => new(message, operationCode);
}