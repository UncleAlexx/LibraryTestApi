namespace BookApi.Infrastructure.Book.Persistence.Configurations.Abstractions;

internal abstract class EntityConfigurationBase<TId, TEntity> : IEntityTypeConfiguration<TEntity> where TId : notnull
    where TEntity : Entity<TId>
{
    protected const string IdRaw = "ID";
    protected const string BookIdRaw = "BookID";

    public abstract void Configure(EntityTypeBuilder<TEntity> builder);
}
