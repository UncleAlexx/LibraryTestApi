using BookApi.Domain.Book.Entities.Pocos;
using BookApi.Domain.Book.Persistence.Dapper.QueriesParameters;
using BookApi.Domain.Book.ValueObjects.Stock;
using BookApi.Infrastructure.Book.Persistence.Constants.Library;
using BookApi.Infrastructure.Book.Persistence.Enums;
using BookApi.Infrastructure.Book.Persistence.Library;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace BookApi.Infrastructure.Book.Persistence.Repositories;

public sealed class BookRepository(LibraryContext context,
    [FromKeyedServices(Databases.Library)] SqlConnection connection) : IBookRepository
{
    private readonly LibraryContext _context = context;
    private readonly SqlConnection _connection = connection;

    public async Task<IEnumerable<BookAggregate>> GetAllAsync()
    {
        var a = await _connection.QueryAsync<BookPoco>(SqlQueries.GetAll);
        var results = a.Select(x => BookAggregate.Create(x.Isbn, x.Author, x.Description, x.Genre, x.Title,
            x.LendingDate, x.ReturnDate, x.BookId, x.StockId, x.LendingId)).Where(x => x.Successful).
            Select(x => x.Entity);
        return results;
    }

    public async Task<BookAggregate?> GetByIdAsync(IdObject id)
    {
        IdParameter.Instance.Id = id.Value;
        var a = await _connection.QuerySingleOrDefaultAsync<BookPoco>(SqlQueries.GetById, IdParameter.Instance);
        return  BookAggregate.Create(a.Isbn, a.Author, a.Description, a.Genre, a.Title, a.LendingDate, a.ReturnDate, 
            a.BookId, a.StockId, a.LendingId).Entity ;
    }

    public async Task<BookAggregate?> GetByIsbnAsync(IsbnObject isbn)
    {
        IsbnParameter.Instance.Isbn = isbn.Value;
        var a = await _connection.QuerySingleOrDefaultAsync<BookPoco>(SqlQueries.GetByIsbn, IsbnParameter.Instance);
        return BookAggregate.Create(a.Isbn, a.Author, a.Description, a.Genre, a.Title, a.LendingDate, a.ReturnDate, 
            a.BookId, a.StockId, a.LendingId).Entity;
    }

    public async Task<BookAggregate?> UpdateAsync(BookAggregate book)
    {
        if (book is null or { Id : not { } })
            return null;
        var b = await GetByIsbnAsync(book.Stock.Isbn);
        return _context.Update(BookAggregate.Create(book.Stock.Isbn.Value, book.Stock.Author.Value, 
            book.Stock.Description.Value, book.Stock.Genre.Value, book.Stock.Title.Value, 
            book.Lending.LendingDate.Value, book.Lending.Return.Value, b.Id.Value, b.Stock.Id.Value, 
            b.Lending.Id.Value).Entity).Entity;
    }

    public async Task<BookAggregate?> AddAsync(BookAggregate book)
    {
        IsbnParameter.Instance.Isbn = book.Stock.Isbn.Value;
        if (book.Stock.Isbn.Value is null)
            return null;
        await _context.Books.AddAsync(book);
        return book;
    }

    public async Task<BookAggregate?> RemoveAsync(IsbnObject isbn)
    {
        IsbnParameter.Instance.Isbn = isbn.Value;
        var a = await _connection.QuerySingleOrDefaultAsync<BookPoco>(SqlQueries.GetByIsbn, IsbnParameter.Instance);
        var entry = _context.Books.Remove(BookAggregate.Create(a.Isbn, a.Author, a.Description, a.Genre, a.Title, 
            a.LendingDate, a.ReturnDate, a.BookId, a.StockId, a.LendingId).Entity);
        return entry.Entity;
    }

}