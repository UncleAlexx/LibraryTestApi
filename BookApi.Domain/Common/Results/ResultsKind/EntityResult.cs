namespace Library.Domain.Common.Results.ResultsKind;

public sealed class EntityResult<TEntity> : ResultBase<TEntity>, IEntityResult<TEntity, EntityResult<TEntity>>
{
    private EntityResult(in bool successful, in TEntity entity) : base(successful) => Entity = entity;

    public static EntityResult<TEntity> Success(in TEntity entity) => new(true, entity);

    public static EntityResult<TEntity> Failed(in TEntity entity) => new(false, entity);
}