namespace Library.Domain.Common.Results.Interfaces;

public interface IValidationResult<TEntity, TCreationResult> : IResult<TEntity> where TCreationResult : 
    IValidationResult<TEntity, TCreationResult>, IResult<TEntity>
{
    public ushort OperationCode { get; init; }
    public IReadOnlyList<ValidationFailure>?  Errors { get; init; }
    public abstract static TCreationResult Success(in TEntity instance);
    public abstract static TCreationResult Failed(in IList<ValidationFailure> errors, in ushort operationCode);
}