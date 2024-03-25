using System.Diagnostics;

namespace Library.Application.Book.Queries.GetAll;

internal sealed class GetAllHandler(IBookRepository repository) :
    IEnumerableQueryHandler<GetAll, BookView, MessageResult<IEnumerable<BookView>>>
{
    private readonly IBookRepository _repository = repository;
    public async Task<MessageResult<IEnumerable<BookView>>> Handle(GetAll request, CancellationToken cancellationToken)
    {
        return await ValidationResultExtensions.FailDbExceptionIfErrorAsync<GetAll, IEnumerable<BookView>>(async () =>
        {
            var books = (await _repository.GetAllAsync()).Select(book =>
            {
                var bookId = BookIdObject.Create(book.BookId);
                return BookView.Create(Stock.Create(IsbnObject.Create(book.Isbn), AuthorObject.Create(book.Author),
                DescriptionObject.Create(book.Description!), GenreObject.Create(book.Genre!), TitleObject.Create(book.Title), bookId,
                IdObject.Create(book.StockId)), Lending.Create(LendingDateObject.Create(book.LendingDate),
                ReturnDateObject.Create(book.ReturnDate), bookId, IdObject.Create(book.LendingId)), bookId);
            }).Where(result => result.Successful).Select(result => result.Entity);
            Trace.WriteLine(books.Any());
            return books.Any() ? MessageResult<IEnumerable<BookView>>.Success(books!) :
                MessageResult<IEnumerable<BookView>>.Failed(new EntityNotFoundError<BookView>().Message, 404);
        });
    }
}
