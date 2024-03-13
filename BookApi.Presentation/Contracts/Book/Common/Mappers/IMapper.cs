using BookApi.Presentation.Contracts.Book.Common;

namespace Library.Presentation.Contracts.Book.Common.Mappers;

internal interface IBookMapper
{
     internal BookPoco ToBookPoco(BookToChangeView view);
}
