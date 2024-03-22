namespace Library.Infrastructure.Book.Persistence;

public sealed class LibraryContext(DbContextOptions<LibraryContext> options) : DbContext(options)
{
    private const string Schema = "Books";

    public DbSet<BookAggregate> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.HasDefaultSchema(Schema);
}
