using BookApi.Domain.Book.Entities;

namespace BookApi.Domain.Book;

public class Book : AggregateRoot<BookIdObject> 
{
    private Book(BookIdObject Id) : base(Id) { }

    public Stock Stock { get; set; }
    public Lending Lending { get; set; }

    public static EntityResult<Book> Create(string isbn, string author, string description, string genre, string title,
        DateTime lendingDate, DateTime returnDate, Guid bookId, Guid stockId, Guid lendingId)
    {
        var id = BookIdObject.Create(bookId);
        var stock = Stock.Create(isbn, author, description, genre, title, id.Value, stockId);
        stock.Entity.BookId = id;
        var lending = Lending.CreateWithValidation(lendingDate, returnDate, id.Value, lendingId); 
        lending.Entity.BookId = id;
        var entity = new Book(id) { Stock = stock.Entity, Lending = lending.Entity };
        return stock.Successful && lending.Successful? EntityResult<Book>.Success(entity) : EntityResult<Book>.Failed(entity);
    }
}