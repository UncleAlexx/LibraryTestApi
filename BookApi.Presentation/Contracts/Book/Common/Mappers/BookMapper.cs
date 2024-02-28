using BookApi.Domain.Book.Entities.Pocos;
using BookApi.Presentation.Contracts.Book.Add;
using BookApi.Presentation.Contracts.Book.Common.Mappers;
using BookApi.Presentation.Contracts.Book.Update;
using Riok.Mapperly.Abstractions;

namespace BookApi.Presentation.Contracts.Book.Common;

[Mapper]
internal partial class BookMapper : IBookMapper
{
    public partial BookPoco ToBookPoco(BookToUpdateView view);

    public partial BookPoco ToBookPoco(BookToAddView view);
}
