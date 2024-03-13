namespace Library.Domain.Book;

public sealed class Book : AggregateRoot<BookIdObject> 
{
    private Book(BookIdObject Id) : base(Id) { }

    public Stock? Stock { get; private set; }
    public Lending? Lending { get; private set; }

    public static EntityResult<Book> Create(in EntityResult<Stock> stock, in EntityResult<Lending> lending, in BookIdObject id)
    {
        var entity = new Book(id) { Stock = stock.Entity, Lending = lending.Entity };
        return stock.Successful && lending.Successful && stock.Entity!.BookId == lending.Entity!.BookId? 
            EntityResult<Book>.Success(entity) : EntityResult<Book>.Failed(entity);
    }
}