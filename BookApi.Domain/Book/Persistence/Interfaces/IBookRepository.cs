namespace Library.Domain.Book.Persistence.Interfaces;

public interface IBookRepository : IRepository<Book>
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(IdObject id);
    Task<Book?> GetByIsbnAsync(IsbnObject isbn);
    Task<Book?> UpdateAsync(Book book);
    Task<Book?> AddAsync(Book book);
    Task<Book?> RemoveAsync(IsbnObject isbn);
}
