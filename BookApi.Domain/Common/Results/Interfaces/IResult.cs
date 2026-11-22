namespace Library.Domain.Common.Results.Interfaces;

public interface IResult<TEntity>
{
    public TEntity? Entity { get; init; }
    public bool Successful { get; init; }
}