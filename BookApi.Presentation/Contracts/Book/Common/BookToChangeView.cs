namespace BookApi.Presentation.Contracts.Book.Common;

internal readonly struct BookToChangeView
{
    public required string Isbn { get; init; }
    public required string Author { get; init; }
    public required string Title { get; init; }
    public required DateTime LendingDate { get; init; }
    public required DateTime ReturnDate { get; init; }
    public string? Genre { get; init; }
    public string? Description { get; init; }
}
