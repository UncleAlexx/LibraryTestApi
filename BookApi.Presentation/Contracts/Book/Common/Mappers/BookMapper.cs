namespace Library.Presentation.Contracts.Book.Common.Mappers;

[Mapper]
internal partial class BookMapper : IBookMapper
{
    public partial BookPoco ToBookPoco(BookToUpdateView view);

    public partial BookPoco ToBookPoco(BookToAddView view);
}
