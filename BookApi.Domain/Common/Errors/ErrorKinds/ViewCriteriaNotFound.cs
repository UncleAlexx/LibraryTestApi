using BookApi.Domain.Common.Errors.Bases;
using System.Runtime.CompilerServices;

namespace BookApi.Domain.Common.Errors.ErrorKinds;

public sealed class ViewCriteriaNotFound<T, TCriteria>(TCriteria criteria, 
    [CallerArgumentExpression(nameof(criteria))] string criteriaName = "") : IError
{
    public string? Message { get; init; } = $"No {typeof(T).Name}s with {criteriaName} = {criteria} found";
}
