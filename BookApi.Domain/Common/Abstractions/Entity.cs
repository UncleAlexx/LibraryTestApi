using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace BookApi.Domain.Common.Models;

public abstract class Entity<TId>(TId id) : IEquatable<Entity<TId>>, IEqualityOperators<Entity<TId>, Entity<TId>, bool>
    where TId : notnull, IEquatable<TId>
{
    public TId Id { get; set; } = id;

    public static bool operator == (Entity<TId>? one, Entity<TId>? other) => one is not null && other is not null && one.Id.Equals(default) is false &&
        other.Id.Equals(default) is false && one.Id.Equals(other!.Id);

    public static bool operator !=(Entity<TId>? one, Entity<TId>? other) => (one == other) is false;

    public bool Equals(Entity<TId>? other) => other! == this;

    public override bool Equals(object? obj) => obj is Entity<TId> entity && entity == this;

    public override int GetHashCode() => Id.GetHashCode();  
}
