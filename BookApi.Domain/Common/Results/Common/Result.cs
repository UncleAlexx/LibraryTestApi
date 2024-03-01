namespace Library.Domain.Common.Results.Common;

public abstract class ResultBase<T>(bool succesful) : IResult<T>
{
    public  T? Entity { get; init; }
    public bool Successful { get; init;} = succesful;
}