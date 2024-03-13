namespace Library.Presentation.Contracts.Book.Update;

public readonly record struct BookToUpdateView
{
    public required string Isbn { get; init; }
    public required string Author { get; init; }
    public required string Title { get; init; }
    public required DateTime LendingDate { get; init; }
    public required DateTime ReturnDate { get; init; }
    public required Guid Id { get; init; }
    public string? Genre { get; init; }
    public string? Description { get; init; }
}
