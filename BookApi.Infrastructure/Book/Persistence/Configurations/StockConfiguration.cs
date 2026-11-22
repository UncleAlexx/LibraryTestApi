namespace BookApi.Infrastructure.Book.Persistence.Configurations;

internal sealed class StockConfiguration : EntityConfigurationBase<BookIdObject, BookAggregate>
{
    public override void Configure(EntityTypeBuilder<BookAggregate> builder)
    {
        builder.OwnsOne(book => book.Stock, stock =>
        {
            stock.Property(stock => stock.Id).HasConversion(idObj => idObj.Value, id => IdObject.Create(id)).ValueGeneratedNever().
                HasColumnName(IdRaw).IsRequired();
            stock.Property(stock => stock.Isbn).HasConversion(isbnObj => isbnObj.Value, isbn => IsbnObject.Create(isbn).Entity!).
                IsFixedLength().IsRequired();
            stock.Property(stock => stock.Title).HasConversion(titleObj => titleObj.Value, title => TitleObject.Create(title).Entity!).
                HasMaxLength(30).IsFixedLength(false).IsRequired();
            stock.Property(stock => stock.Description).HasConversion(descObj => descObj!.Value, description => 
                DescriptionObject.Create(description).Entity).IsFixedLength(false).HasMaxLength(100);
            stock.Property(stock => stock.Genre).HasConversion(genreObj => genreObj!.Value, genre => GenreObject.Create(genre).Entity).
                IsFixedLength(false).HasMaxLength(40);
            stock.Property(stock => stock.Author).HasConversion(authorObj => authorObj.Value, author => 
                AuthorObject.Create(author).Entity!).IsFixedLength(false).HasMaxLength(40).IsRequired();
            stock.Property(stock => stock.BookId).HasConversion(bookIdObj => bookIdObj.Value, bookId => BookIdObject.Create(bookId)).
                IsRequired().HasColumnName(BookIdRaw);
            stock.WithOwner(stock => stock.Book).HasForeignKey(stock => stock.BookId).HasPrincipalKey(book => book.Id);
            stock.HasKey([nameof(Stock.Id), nameof(Stock.BookId)]);
            stock.HasIndex(stock => stock.Isbn).IsUnique().IsClustered(false).HasDatabaseName("UK_Isbn");
            stock.HasIndex(stock => stock.BookId).IsUnique().IsClustered(false).HasDatabaseName("UK_BookID");
            stock.ToTable(nameof(Stock));
        });
    }
}
