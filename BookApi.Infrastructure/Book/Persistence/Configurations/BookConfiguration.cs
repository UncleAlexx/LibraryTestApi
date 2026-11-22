namespace BookApi.Infrastructure.Book.Persistence.Configurations;
 
internal sealed class BookConfiguration : EntityConfigurationBase<BookIdObject, BookAggregate>
{
    public override void Configure(EntityTypeBuilder<BookAggregate> builder)
    {
        builder.Property(book => book.Id).HasConversion(bookIdObject => bookIdObject.Value, bookId => 
            BookIdObject.Create(bookId)).ValueGeneratedNever().HasColumnName(IdRaw);
        builder.HasKey(book => book.Id);
        builder.Property<DateTime>("LastModified").ValueGeneratedOnAddOrUpdate();
    }
}
