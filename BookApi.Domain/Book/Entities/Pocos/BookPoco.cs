namespace BookApi.Domain.Book.Entities.Pocos;

public readonly record struct BookPoco
{
    public required string Isbn { get; init; }
    public required string Author { get; init; }
    public required string Title { get; init; }
    public required DateTime LendingDate { get; init; }
    public required DateTime ReturnDate { get; init; }
    public string? Genre { get; init; }
    public string? Description { get; init; }
    public Guid BookId {get; init; }
    public Guid StockId { get; init; }
    public Guid LendingId { get; init; }
}
