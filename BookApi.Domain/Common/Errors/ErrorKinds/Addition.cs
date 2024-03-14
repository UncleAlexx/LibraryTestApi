namespace Library.Domain.Common.Errors.ErrorKinds;

public sealed class Addition<T, TCriteria>(TCriteria criteria, 
    [CallerArgumentExpression(nameof(criteria))] string criteriaName = "") : IError
{
    public string Message { get; init; } = $"Cannot Add {typeof(T).Name} because {typeof(T).Name} with " +
        $"{criteriaName} = {criteria} already exists in the database";
}
