namespace Library.Domain.Book.Entities;

public sealed class Stock : Entity<IdObject>
{
    [SetsRequiredMembers]
    private Stock(IsbnObject isbn, GenreObject? genre, TitleObject title, AuthorObject author,
        DescriptionObject? description, IdObject id, BookIdObject bookId) : base(id) =>
        (Isbn, Title, Author, Genre, Description, BookId) = (isbn, title, author, genre, description, bookId);

    public BookIdObject BookId { get; private set; }

    public Book? Book { get; private set; }
    public required IsbnObject Isbn { get; set; }
    public required TitleObject Title { get; set; }
    public required AuthorObject Author { get; set; }
    public GenreObject? Genre { get; set; }
    public DescriptionObject? Description { get; set; }

    public static EntityResult<Stock> Create(in EntityResult<IsbnObject> isbn, in EntityResult<AuthorObject> author, 
        in EntityResult<DescriptionObject> description, in EntityResult<GenreObject> genre, in EntityResult<TitleObject> title, 
        in BookIdObject bookId, in IdObject id)
    {
        Stock instance = new(isbn.Entity!, genre.Entity, title.Entity!, author.Entity!, description.Entity, id, bookId);
        if (isbn.Successful && author.Successful && description.Successful && genre.Successful && title.Successful)
            return EntityResult<Stock>.Success(instance);
        return EntityResult<Stock>.Failed(instance);
    }
}
