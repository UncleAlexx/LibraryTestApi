namespace Library.Domain.Book.Persistence.Interfaces;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
