namespace Library.Domain.Common.Results.ResultsKind;

public sealed class ValidationResult<TEntity> : ResultBase<TEntity>, IValidationResult<TEntity, ValidationResult<TEntity>>
{
    private ValidationResult(in IList<ValidationFailure> errors, in ushort operationCode) : base(false)
        => (Errors, OperationCode) = (new ReadOnlyCollection<ValidationFailure>(errors), operationCode);
    
    private ValidationResult(in TEntity entity) : base(true) => Entity = entity;

    public IReadOnlyList<ValidationFailure>? Errors { get; init; }
    public ushort OperationCode { get; init; } = 200;

    public static ValidationResult<TEntity> Failed(in IList<ValidationFailure> errors, in ushort operationCode) => 
        new(errors, operationCode);

    public static ValidationResult<TEntity> Success(in TEntity instance) => new(instance);
}
