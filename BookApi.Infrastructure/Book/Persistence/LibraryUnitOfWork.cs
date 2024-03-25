namespace BookApi.Infrastructure.Book.Persistence;

public sealed class LibraryUnitOfWork(LibraryContext context) : IUnitOfWork
{
    private readonly LibraryContext _context = context;

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}