namespace BookApi.Domain.Common.Results.Interfaces;

public interface IResult<T2>
{
    public T2? Entity { get; init; }

    public bool Successful { get; init; }
}