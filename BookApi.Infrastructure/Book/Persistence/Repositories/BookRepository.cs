namespace Library.Infrastructure.Book.Persistence.Repositories;

public sealed class BookRepository(LibraryContext context,
    [FromKeyedServices(Databases.Library)] SqlConnection connection) : IBookRepository
{
    private readonly LibraryContext _context = context;
    private readonly SqlConnection _connection = connection;

    public async Task<IEnumerable<BookPoco>> GetAllAsync() => await _connection.QueryAsync<BookPoco>(SqlQueries.GetAll);
    
    public async Task<BookPoco?> GetByIdAsync(BookIdObject id)
    {
        IdParameter.Instance.Id = id.Value;
        return await GetSingleBaseAsync<IdParameter, Guid>(IdParameter.Instance, SqlQueries.GetById);
    }

    public async Task<BookPoco?> GetByIsbnAsync(IsbnObject isbn)
    {
        IsbnParameter.Instance.Isbn = isbn.Value;
        return await GetSingleBaseAsync<IsbnParameter, string>(IsbnParameter.Instance, SqlQueries.GetByIsbn);
    }

    public BookAggregate? Update(BookAggregate book) => _context.Books.Update(book).Entity;

    public async Task<BookAggregate?> AddAsync(BookAggregate book) => (await _context.Books.AddAsync(book)).Entity;

    public async Task<BookAggregate?> RemoveAsync(IsbnObject isbn)
    {
        var pocoToDelete = await GetByIsbnAsync(isbn);
        BookAggregate book = _context.Books.Find(BookIdObject.Create(pocoToDelete!.BookId))!;
        return _context.Remove(book).Entity;
    }

    public Guid GetLendingIdByIsbn(IsbnObject isbn) => GetByIsbnBase(isbn, SqlQueries.GetLendingIdByIsbn);

    public Guid GetStockIdByIsbn(IsbnObject isbn) => GetByIsbnBase(isbn, SqlQueries.GetStockIdByIsbn);

    public Guid GetIdByIsbn(IsbnObject isbn) => GetByIsbnBase(isbn, SqlQueries.GetIdByIsbn);
    
    private async Task<BookPoco?> GetSingleBaseAsync<TParameter, TValue>(TParameter isbn, [NotNull] string query)
        where TParameter : QueryParameter<TParameter, TValue> =>
        await _connection.QuerySingleOrDefaultAsync<BookPoco?>(query!, isbn);

    private Guid GetByIsbnBase([NotNull] IsbnObject isbn, [NotNull] string query)
    {
        IsbnParameter.Instance.Isbn = isbn.Value;
        return _connection.QuerySingleOrDefault<Guid>(query!, IsbnParameter.Instance);
    }
}