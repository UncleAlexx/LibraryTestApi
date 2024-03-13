namespace Library.Domain.Common.Results.Interfaces;

public interface IEntityResult<TEntity, TCreationResult> : IResult<TEntity> where TCreationResult : 
    IEntityResult<TEntity, TCreationResult>  
{
    public abstract static TCreationResult Success(in TEntity entity);
    public abstract static TCreationResult Failed(in TEntity entity);
}
