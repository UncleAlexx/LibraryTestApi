namespace Library.Domain.Common.Errors.ErrorKinds;

public sealed class EntityCriteriaNotFoundError<TEntity, TCriteria>(in TCriteria criteria, 
     in string criteriaName) : IError
{
    public string Message { get; init; } = $"No {typeof(TEntity).Name}s with {criteriaName} = {criteria} found";
}
