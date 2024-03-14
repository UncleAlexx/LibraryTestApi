namespace Library.Presentation.Contracts.Book.Common.Mappers;

[Mapper]
internal sealed partial class BookMapper : IBookMapper
{
    public partial BookPoco ToBookPoco(BookToChangeView view);
}
