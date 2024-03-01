namespace Library.Presentation.Contracts.Book.Common.Mappers;

internal interface IBookMapper
{
     internal BookPoco ToBookPoco(BookToUpdateView view);
     internal BookPoco ToBookPoco(BookToAddView view);
}
