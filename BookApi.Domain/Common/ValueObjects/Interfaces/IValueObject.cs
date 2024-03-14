namespace Library.Domain.Common.ValueObjects.Interfaces;

internal interface IValueObject<TEntity, TCreateReturnType>
{
    [MaybeNull]
    abstract static string PropertyName { get; }
    TEntity Value { get; init; }
    abstract string ErrorMessage { get; init; }
    abstract static TCreateReturnType Create(in TEntity entity);
}