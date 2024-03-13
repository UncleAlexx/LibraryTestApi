namespace Library.Domain.Common.Errors.ErrorKinds;

public sealed class InsertionError<TEntity, TCriteria>(in TCriteria criteria, 
     in string criteriaName) : IError
{
    public string Message { get; init; } = $"Cannot insert {typeof(TEntity).Name} because {typeof(TEntity).Name} with " +
        $"{criteriaName} = {criteria} already exists in the database";
}
