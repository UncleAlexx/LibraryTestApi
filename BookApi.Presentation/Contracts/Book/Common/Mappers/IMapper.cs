using BookApi.Domain.Book.Entities.Pocos;
using BookApi.Presentation.Contracts.Book.Add;
using BookApi.Presentation.Contracts.Book.Update;

namespace BookApi.Presentation.Contracts.Book.Common.Mappers;

internal interface IBookMapper
{
     internal BookPoco ToBookPoco(BookToUpdateView view);
     internal BookPoco ToBookPoco(BookToAddView view);
}
