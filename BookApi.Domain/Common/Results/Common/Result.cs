namespace Library.Domain.Common.Results.Common;

public abstract class ResultBase<TEntity>(in bool succesful) : IResult<TEntity>
{
    public TEntity? Entity { get; init; }
    public bool Successful { get; init;} = succesful;
}