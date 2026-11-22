using Library.Domain.Book.Entities.Pocos;

namespace Library.Domain.Book.Persistence.Interfaces;

public interface IBookRepository : IRepository<Book>
{
    Guid GetLendingIdByIsbn(IsbnObject isbn);
    Guid GetStockIdByIsbn(IsbnObject isbn);
    Guid GetIdByIsbn(IsbnObject isbn);  
    Task<IEnumerable<BookPoco>> GetAllAsync();
    Task<BookPoco?> GetByIdAsync(BookIdObject id);
    Task<BookPoco?> GetByIsbnAsync(IsbnObject isbn);
    Book? Update(Book book);
    Task<Book?> AddAsync(Book book);
    Task<Book?> RemoveAsync(IsbnObject isbn);
}
