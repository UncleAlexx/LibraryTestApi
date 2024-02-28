using BookApi.Domain.Book.ValueObjects.Lending;
namespace BookApi.Domain.Book.Entities;

public sealed class Stock : Entity<IdObject>
{
    [SetsRequiredMembers]
    private Stock(IsbnObject isbn, GenreObject? genre, TitleObject title, AuthorObject author, DescriptionObject? description, 
        IdObject id, BookIdObject bookId) : base(id)
    {
        Isbn = isbn;
        Title = title;
        Author = author;
        Genre = genre;
        Description = description;
        BookId = bookId;
    }

    public BookIdObject BookId { get; set; }


    [JsonIgnore]
    public Book? Book { get; set; }
    public required IsbnObject Isbn { get; set; }
    public required TitleObject Title { get; set; }
    public required AuthorObject Author { get; set; }
    public GenreObject? Genre { get; set; }
    public DescriptionObject? Description { get; set; }

    public static EntityResult<Stock> Create(string isbn, string author, string description, string genre, string title, Guid bookId, Guid id)
    {
        var strongIsbn = IsbnObject.Create(isbn);
        var strongAuthor = AuthorObject.Create(author);
        var strongDescription = DescriptionObject.Create(description);
        var strongGenre = GenreObject.Create(genre);
        var strongTitle = TitleObject.Create(title);

        Stock instance = new(strongIsbn.Entity, strongGenre.Entity, strongTitle.Entity, strongAuthor.Entity,
            strongDescription.Entity, IdObject.Create(id), BookIdObject.Create(bookId));
        if (strongIsbn.Successful && strongAuthor.Successful && strongDescription.Successful && strongGenre.Successful && 
            strongTitle.Successful)
            return EntityResult<Stock>.Success(instance);
        return EntityResult<Stock>.Failed(instance);
    }
}
