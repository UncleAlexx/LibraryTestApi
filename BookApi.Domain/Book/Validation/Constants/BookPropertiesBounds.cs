using BookApi.Domain.Common.Validation;

namespace BookApi.Domain.Book.Validation.Constants;

public readonly ref struct BookPropertiesBounds()
{
    private static readonly DateTime _centuryMinimum = new(2000, 1, 1);
    private static readonly DateTime _centuryMaximum = new(2099, 12, 31);

    public static readonly Bounds<DateTime> Return = new(_centuryMinimum, _centuryMaximum);

    public static readonly Bounds<int> Description = new(20, 100);
    public static readonly Bounds<int> Title = new(3, 30);
    public static readonly Bounds<int> Author = new(13, 40);
    public static readonly Bounds<int> Isbn = new(17, 17);
    public static readonly Bounds<int> Genre = new(5, 30);

    public readonly Bounds<DateTime> UpToDate = new(_centuryMinimum, DateTime.Today.AddDays(1));
}