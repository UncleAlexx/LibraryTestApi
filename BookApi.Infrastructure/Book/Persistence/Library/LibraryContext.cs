namespace Library.Infrastructure.Book.Persistence.Library;

public class LibraryContext(DbContextOptions<LibraryContext> options) : DbContext(options)
{
    private const string Schema = "Books";

    public DbSet<BookAggregate> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.HasDefaultSchema(Schema);

        var a = modelBuilder.Entity<BookAggregate>();

        a.Property(x => x.Id).HasConversion(x => x.Value, x => BookIdObject.CreateUnique()).ValueGeneratedNever().HasColumnName("ID");
        a.HasKey(x => x.Id);
        a.OwnsOne(x => x.Stock, stock =>
        {
            stock.Property(x => x.Id).HasConversion(x => x.Value, x=> IdObject.Create(x)).ValueGeneratedNever().
                HasColumnName("ID").IsRequired();
            stock.Property(x => x.Isbn).HasConversion(x => x.Value, x => IsbnObject.Create(x).Entity).
                IsFixedLength().IsRequired();
            stock.Property(x => x.Title).HasConversion(x => x.Value, x => TitleObject.Create(x).Entity).HasMaxLength(30).IsFixedLength(false).IsRequired();
            stock.Property(x => x.Description).HasConversion(x => x.Value, x => DescriptionObject.Create(x).Entity).IsFixedLength(false).HasMaxLength(100);
            stock.Property(x => x.Genre).HasConversion(x => x.Value, x => GenreObject.Create(x).Entity).IsFixedLength(false).HasMaxLength(40);
            stock.Property(x => x.Author).HasConversion(x => x.Value, x => AuthorObject.Create(x).Entity).IsFixedLength(false).HasMaxLength(40).IsRequired();
            stock.Property(x => x.BookId).HasConversion(x => x.Value, x => BookIdObject.Create(x)).IsRequired().HasColumnName("BookID");
            stock.WithOwner(x => x.Book).HasForeignKey(x => x.BookId).HasPrincipalKey(x => x.Id);
            stock.HasKey([nameof(Stock.Id), nameof(Stock.BookId)]);
            stock.HasIndex(x => x.Isbn).IsUnique().IsClustered(false).HasDatabaseName("UK_Isbn");
            stock.HasIndex(x => x.BookId).IsUnique().IsClustered(false).HasDatabaseName("UK_BookID");
            stock.ToTable(nameof(Stock));
        });

        a.OwnsOne(x => x.Lending, lending =>
        {
            lending.Property(x => x.LendingDate).HasConversion(X => X.Value, x => LendingDateObject.Create(x).Entity).HasPrecision(2, 2).IsRequired();
            lending.Property(X => X.Return).HasConversion(X => X.Value, x => ReturnDateObject.Create(x).Entity).HasPrecision(2, 2).IsRequired();
            lending.Property(x => x.Id).HasConversion(X => X.Value, x => IdObject.Create(x)).HasColumnName("ID").
                ValueGeneratedNever().IsRequired();
            lending.HasIndex(x => x.BookId).IsUnique().IsClustered(false).HasDatabaseName("UK_BookID");
            lending.Property(x => x.BookId).HasConversion(x => x.Value, x => BookIdObject.Create(x)).HasColumnName("BookID").IsRequired();
            lending.WithOwner(x => x.Book).HasForeignKey(x => x.BookId).HasPrincipalKey(x => x.Id);
            lending.HasKey([nameof(Lending.Id), nameof(Lending.BookId)]);
            lending.ToTable(nameof(Lending));
        });
    }

}
