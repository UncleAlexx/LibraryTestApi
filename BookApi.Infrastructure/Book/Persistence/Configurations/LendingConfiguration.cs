namespace BookApi.Infrastructure.Book.Persistence.Configurations;

internal sealed class LendingConfiguration : EntityConfigurationBase<BookIdObject, BookAggregate>
{
    public override void Configure(EntityTypeBuilder<BookAggregate> builder)
    {
        builder.OwnsOne(book => book.Lending, lending =>
        {
            lending.Property(lending => lending.LendingDate).HasConversion(lDateObj => lDateObj.Value, lending => 
                LendingDateObject.Create(lending).Entity!).HasPrecision(2, 2).IsRequired();
            lending.Property(lending => lending.Return).HasConversion(rDateObj => rDateObj.Value, returnDate => 
                ReturnDateObject.Create(returnDate).Entity!).HasPrecision(2, 2).IsRequired();
            lending.Property(lending => lending.Id).HasConversion(idObj => idObj.Value, Id => 
                IdObject.Create(Id)).HasColumnName(IdRaw).ValueGeneratedNever().IsRequired();
            lending.Property(lending => lending.BookId).HasConversion(bookIdObject => bookIdObject.Value, bookId => 
                BookIdObject.Create(bookId)).HasColumnName(BookIdRaw).IsRequired();
            lending.HasIndex(lending => lending.BookId).IsUnique().IsClustered(false).HasDatabaseName("UK_BookID");
            lending.WithOwner(lending => lending.Book).HasForeignKey(lending => lending.BookId).HasPrincipalKey(book => book.Id);
            lending.HasKey([nameof(Lending.Id), nameof(Lending.BookId)]);
            lending.ToTable(nameof(Lending));
        });
    }
}
