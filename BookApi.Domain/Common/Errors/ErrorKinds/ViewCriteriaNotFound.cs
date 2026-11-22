namespace Library.Domain.Common.Errors.ErrorKinds;

public sealed class ViewCriteriaNotFound<T, TCriteria>(TCriteria criteria, 
    [CallerArgumentExpression(nameof(criteria))] string criteriaName = "") : IError
{
    public string Message { get; init; } = $"No {typeof(T).Name}s with {criteriaName} = {criteria} found";
}
