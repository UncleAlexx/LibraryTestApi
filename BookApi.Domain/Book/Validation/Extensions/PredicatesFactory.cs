namespace Library.Domain.Book.Validation.Extensions;

public static class PredicatesFactory
{
    private static readonly ReadOnlyDictionary<BookPropertiesNames, Regex> _bookPropertiesPatterns = new(
        new Dictionary<BookPropertiesNames, Regex>(Enum.GetValues<BookPropertiesNames>().Length)
        {
            [BookPropertiesNames.Isbn] = ValidationPatterns.Isbn(),
            [BookPropertiesNames.Title] = ValidationPatterns.Title(),
            [BookPropertiesNames.Genre] = ValidationPatterns.Genre(),
            [BookPropertiesNames.Author] = ValidationPatterns.Author(),
            [BookPropertiesNames.Description] = ValidationPatterns.Description(),
        });

    public static bool IsMatch(this BookPropertiesNames bookPropertyName, string propertyValue)
    {
        if (propertyValue is null)
            return false;
        Match match = _bookPropertiesPatterns[bookPropertyName].Match(propertyValue);
        static bool IsLanguageUnique(Match match) => (match.Groups[RegexNamedGroups.Cyryllic].Success &&
            match.Groups[RegexNamedGroups.Latin].Success) is false;
        return match.Success && (bookPropertyName is BookPropertiesNames.Isbn || IsLanguageUnique(match));
    }

    public static bool IsUpToDate(this DateTime date)
    {
        var boundary = new BookPropertiesBounds().UpToDate;
        return date >= boundary.Min && date <= boundary.Max;
    }

    public static bool EnsureLesser(this DateTime min, DateTime max) => max > min;
}

file static class RegexNamedGroups
{
    public const string Cyryllic = "Cyryllic";
    public const string Latin = "Latin";
}