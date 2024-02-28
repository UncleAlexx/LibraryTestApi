namespace BookApi.Domain.Common.Results.Interfaces;

public interface IEntityResult<T, T2> : IResult<T> where T2 : IEntityResult<T, T2>  
{
    public abstract static T2 Success(T entity);
    public abstract static T2 Failed(T entity);
}
