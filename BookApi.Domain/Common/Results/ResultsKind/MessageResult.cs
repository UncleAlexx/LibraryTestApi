namespace Library.Domain.Common.Results.ResultsKind;

public sealed class MessageResult<TEntity> : ResultBase<TEntity>, IMessageResult<TEntity, MessageResult<TEntity>>
{
    private MessageResult(in TEntity entity) : base(true) => Entity = entity;

    private MessageResult(in string message, in ushort operationCode) : base(false) => 
        (Message, OperationCode) = (message, operationCode);

    public string? Message { get; init; }

    public ushort OperationCode { get; init; } = 200;

    public static MessageResult<TEntity> Success(in TEntity entity) => new(entity);

    public static MessageResult<TEntity> Failed(in string message, in ushort operationCode) => new(message, operationCode);
}