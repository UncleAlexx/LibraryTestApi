namespace Library.Domain.Common.Results.Interfaces;

public interface IValidationResult<T, T2> : IResult<T> where T2 : IValidationResult<T, T2>, IResult<T>
{
    public ushort OperationCode { get; init; }
    public IReadOnlyList<ValidationFailure>?  Errors { get; init; }
    public abstract static T2 Success(T instance);
    public abstract static T2 Failed(IList<ValidationFailure> errors, ushort operationCode);
}