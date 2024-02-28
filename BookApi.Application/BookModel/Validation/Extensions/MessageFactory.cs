namespace BookApi.Application.BookModel.Validation.Extensions;

internal static class MessagesFactory
{
    private const string _mustBe = $"{{PropertyName}} {Constants.RawMust} {Constants.RawBe}";
    private const string _mustContain = $"{{PropertyName}} {Constants.RawMust} {Constants.RawContain}";
    private const string _separatedRule = $"separated by {Constants.RawOne} {Constants.RawSpace} {Constants.RawWritten} {Constants.RawIn} " +
        $"{Constants.RawLatin} {Constants.RawOnly} {Constants.RawOr} {Constants.RawIn} {Constants.RawCyrillic} {Constants.RawOnly}";
    private const string LendingMessage = $"{_mustBe} {Constants.RawUpToDate} {Constants.RawAnd} of {Constants.CurrentCentury}";
    private const string GenreMessage = $"{_mustContain} {Constants.RawOne} {Constants.RawOr} {Constants.RawTwo} {Constants.RawWord}s {_separatedRule}";
    private const string DescriptionMessage = $"{_mustBe} {Constants.RawEmpty} {Constants.RawOr} {Constants.RawContain} {Constants.RawWord}s " +
        $"{_separatedRule}";
    private const string TitleMessage = $"{_mustBe} at least 5 {Constants.RawChar}s {Constants.RawOr} {Constants.RawContain} " +
        $"{Constants.RawTwo} {Constants.RawWord} {_separatedRule}";
    private const string AuthorMessage = $"{_mustContain} 3 {Constants.RawWord}s: {Constants.RawName}, {Constants.RawSurname}," +
        $" {Constants.RawPatronymic}, {_separatedRule}";
    private const string IsbnMessage = $"{_mustBe} {Constants.RawIn} {Constants.RawFormat}: {Constants.IsbnFormat}";
    private const string ReturnMessage = $"{_mustBe} greater than {Constants.RawLending}";

    private static readonly ReadOnlyDictionary<BookPropertiesNames, string> _bookPropertiesMessages = new(new Dictionary<BookPropertiesNames, string>
    {
        [BookPropertiesNames.Author] = AuthorMessage,
        [BookPropertiesNames.Description] = DescriptionMessage,
        [BookPropertiesNames.Title] = TitleMessage,
        [BookPropertiesNames.Isbn] = IsbnMessage,
        [BookPropertiesNames.Lending] = LendingMessage,
        [BookPropertiesNames.Genre] = GenreMessage,
        [BookPropertiesNames.Return] = ReturnMessage
    });

    public static string BuildBookMessage(this BookPropertiesNames bookProperties) =>
        $"{_bookPropertiesMessages[bookProperties]}, current value = {{PropertyValue}}";
}

file static class Constants
{
    public const string RawAnd = "and";
    public const string RawOr = "or";
    public const string RawIn = "in";
    public const string CurrentCentury = "21 century";
    public const string RawCyrillic = "cyrillic";
    public const string RawLatin = "latin";
    public const string RawMust = "must";
    public const string RawUpToDate = "up to date";
    public const string RawBe = "be";
    public const string RawOne = "one";
    public const string RawTwo = "two";
    public const string RawContain = "contain";
    public const string RawChar = "char";
    public const string RawFormat = "format";
    public const string IsbnFormat = "'###-#-##-######-#'";
    public const string RawName = "name";
    public const string RawSurname = "surname";
    public const string RawSpace = "space";
    public const string RawPatronymic = "patronymic";

    public const string RawLending = "lending";
    public const string RawEmpty = "empty";
    public const string RawWord = "word";
    public const string RawOnly = "patronymic";
    public const string Letter = "letter";
    public const string RawWritten = "written";
}
