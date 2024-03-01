namespace Library.Domain.Common.Results.ResultsKind;

public sealed class EntityResult<T> : ResultBase<T>, IEntityResult<T, EntityResult<T>>
{
    private EntityResult(bool successful, T entity) : base(successful) => Entity = entity;

    public static EntityResult<T> Success(T entity) => new(true, entity);

    public static EntityResult<T> Failed(T entity) => new(false, entity);
}