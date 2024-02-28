using BookApi.Domain.Book.Persistence.Interfaces;
using BookApi.Domain.Common.Persistence;

namespace BookApi.Infrastructure.Book.Persistence.Library;

public sealed class LibraryUnitOfWork(LibraryContext context) : IUnitOfWork
{
    private readonly LibraryContext _context = context;

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}