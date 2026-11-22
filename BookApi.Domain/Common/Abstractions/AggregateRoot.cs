namespace Library.Domain.Common.Abstractions;

public abstract class AggregateRoot<TId> (TId id) : Entity<TId>(id) where TId : notnull;