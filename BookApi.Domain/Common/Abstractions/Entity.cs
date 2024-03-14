namespace Library.Domain.Common.Abstractions;

public abstract class Entity<TId>(TId id) : IEquatable<Entity<TId>>, IEqualityOperators<Entity<TId>, Entity<TId>, bool>
    where TId : notnull
{
    public TId Id { get; set; } = id;

    public static bool operator == (Entity<TId>? one, Entity<TId>? other) => one is not null &&
        other is not null && one.Id is not null &&  other.Id is not null && one.Id.Equals(other!.Id);

    public static bool operator !=(Entity<TId>? one, Entity<TId>? other) => (one == other) is false;

    public bool Equals(Entity<TId>? other) => other! == this;

    public override bool Equals(object? obj) => obj is Entity<TId> entity && entity == this;

    public override int GetHashCode() => Id.GetHashCode();  
}
