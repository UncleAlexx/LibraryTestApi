namespace Library.Domain.Common.Results.Interfaces;

public interface IMessageResult <TInstance, TCreationResult> : IResult<TInstance>
    where TCreationResult : IMessageResult<TInstance, TCreationResult>
{
    public ushort OperationCode { get; init; }
    public string? Message { get; init; }
    public abstract static TCreationResult Success(in TInstance instance);
    public abstract static TCreationResult Failed(in string message, in ushort operationCode);
}