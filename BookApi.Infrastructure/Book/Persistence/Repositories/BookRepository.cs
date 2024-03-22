using BookApi.Infrastructure.Book.Persistence;

namespace Library.Infrastructure.Book.Persistence.Repositories;

public sealed class BookRepository(LibraryContext context,
    [FromKeyedServices(Databases.Library)] SqlConnection connection) : IBookRepository
{
    private readonly LibraryContext _context = context;
    private readonly SqlConnection _connection = connection;

    public async Task<IEnumerable<BookAggregate>> GetAllAsync()
    {
        var allPocos = await _connection.QueryAsync<BookPoco>(SqlQueries.GetAll);
        var allEntities = allPocos.Select(book =>
        {
            var bookId = BookIdObject.Create(book.BookId);
            return BookAggregate.Create(Stock.Create(IsbnObject.Create(book.Isbn), AuthorObject.Create(book.Author),
            DescriptionObject.Create(book.Description!), GenreObject.Create(book.Genre!), TitleObject.Create(book.Title), bookId,
            IdObject.Create(book.StockId)), Lending.Create(LendingDateObject.Create(book.LendingDate),
            ReturnDateObject.Create(book.ReturnDate), bookId, IdObject.Create(book.LendingId)), bookId);
        }).Where(result => result.Successful).Select(result => result.Entity);
        return allEntities!;
    }

    public async Task<BookAggregate?> GetByIdAsync(BookIdObject id)
    {
        IdParameter.Instance.Id = id.Value;
        return await GetSingleBaseAsync<IdParameter, Guid>(IdParameter.Instance, SqlQueries.GetById);
    }

    private async Task<Guid> GetIdByIsbnBaseAsync(IsbnObject isbn, string query)
    {
        IsbnParameter.Instance.Isbn = isbn.Value;
        return await _connection.QuerySingleOrDefaultAsync<Guid>(query, IsbnParameter.Instance);
    }

    public async Task<Guid> GetStockIdByIsbnAsync(IsbnObject isbn) => await GetIdByIsbnBaseAsync(isbn, SqlQueries.GetStockIdByIsbn);

    public async Task<Guid> GetLendingIdByIsbnAsync(IsbnObject isbn) => await GetIdByIsbnBaseAsync(isbn, SqlQueries.GetLendingIdByIsbn);

    public async Task<Guid> GetIdByIsbnAsync(IsbnObject isbn) => await GetIdByIsbnBaseAsync(isbn, SqlQueries.GetIdByIsbn);

    public async Task<BookAggregate?> GetByIsbnAsync(IsbnObject isbn)
    {
        IsbnParameter.Instance.Isbn = isbn.Value;
        return await GetSingleBaseAsync<IsbnParameter, string>(IsbnParameter.Instance, SqlQueries.GetByIsbn);
    }

    private async Task<BookAggregate?> GetSingleBaseAsync<TParameter, TValue>(TParameter isbn, string query) 
        where TParameter : QueryParameter<TParameter, TValue>
    {
        if (query is null or "")
            return null;
        var poco = await _connection.QuerySingleOrDefaultAsync<BookPoco?>(query!, isbn);
        if (poco is null)
            return null;
        var bookId = BookIdObject.Create(poco.BookId);
        return BookAggregate.Create(Stock.Create(IsbnObject.Create(poco.Isbn), AuthorObject.Create(poco.Author),
            DescriptionObject.Create(poco.Description!), GenreObject.Create(poco.Genre!), TitleObject.Create(poco.Title), bookId,
            IdObject.Create(poco.StockId)), Lending.Create(LendingDateObject.Create(poco.LendingDate),
            ReturnDateObject.Create(poco.ReturnDate), bookId, IdObject.Create(poco.LendingId)), bookId).Entity;
    }
    public async Task<BookAggregate?> UpdateAsync(BookAggregate book)
    {
        if (book is null or { Stock: null} or { Lending: null} || (await GetByIsbnAsync(book!.Stock.Isbn) is null))
            return null;
        _context.Books.Update(book);
        return book;
    }

    public async Task<BookAggregate?> AddAsync(BookAggregate book)
    {
        if (book is null or {Stock: null} or { Stock.Isbn: null} || (await GetByIsbnAsync(book!.Stock!.Isbn)) is not null)
            return null;
        return (await _context.Books.AddAsync(book)).Entity;
    }

    public async Task<BookAggregate?> RemoveAsync(IsbnObject isbn)
    {
        var book = await GetByIsbnAsync(isbn);
        if (book is null or { Id: null } or { Stock: null } or { Lending: null })
            return null;
        var entry = _context.Books.Remove(book!);
        return entry.Entity;
    }
}