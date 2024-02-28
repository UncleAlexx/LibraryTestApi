namespace BookApi.Domain.Common.Results.ResultsKind;

public class ValidationResult<T> : ResultBase<T>, IValidationResult<T, ValidationResult<T>>
{
    private ValidationResult(IList<ValidationFailure> errors, ushort operationCode) : base(false)
        => (Errors, OperationCode) = (new ReadOnlyCollection<ValidationFailure>(errors), operationCode);
    
    private ValidationResult(T entity) : base(true) => Entity = entity;

    public IReadOnlyList<ValidationFailure>? Errors { get; init; }
    public ushort OperationCode { get; init; } = 200;

    public static ValidationResult<T> Failed(IList<ValidationFailure> errors, ushort operationCode) => new(errors, operationCode);

    public static ValidationResult<T> Success(T instance) => new(instance);
}
