namespace Library.Domain.Common.Abstractions.ValueObjects.Constants;

internal static class ValidationMessages
{
    private const string MessageBase = ", current value = {PropertyValue}";
    private const string MustBe = $"'{{PropertyName}}' {Constants.Must} {Constants.Be}";
    private const string MustContain = $"'{{PropertyName}}' {Constants.Must} {Constants.Contain}";
    private const string SepatedByRule = $"separated by {Constants.One} {Constants.Space} {Constants.Written} {Constants.In} " +
        $"{Constants.Latin} {Constants.Only} {Constants.Or} {Constants.In} {Constants.Cyrillic} {Constants.Only}";
    public const string GenreMessage = $"{MustContain} {Constants.One} {Constants.Or} {Constants.Two} {Constants.Word}s " +
        $"{SepatedByRule}{MessageBase}";
    public const string DescriptionMessage = $"{MustBe} {Constants.Empty} {Constants.Or} {Constants.Contain} {Constants.Word}s " +
        $"{SepatedByRule}{MessageBase}";
    public const string TitleMessage = $"{MustBe} at least 5 {Constants.Char}s {Constants.Or} {Constants.Contain} " +
        $"{Constants.Two} {Constants.Word} {SepatedByRule}{MessageBase}";
    public const string AuthorMessage = $"{MustContain} 3 {Constants.Word}s: {Constants.Name}, {Constants.Surname}," +
        $" {Constants.Patronymic}, {SepatedByRule}{MessageBase}";
    public const string IsbnMessage = $"{MustBe} {Constants.In} {Constants.Format}: {Constants.IsbnFormat}{MessageBase}";
    public const string ReturnMessage = $"{MustBe} greater than {Constants.Lending}";
}

file static class Constants
{
    public const string And = "and";
    public const string Or = "or";
    public const string In = "in";
    public const string CurrentCentury = "21 century";
    public const string Cyrillic = "cyrillic";
    public const string Latin = "latin";
    public const string Must = "must";
    public const string UpToDate = "up to date";
    public const string Be = "be";
    public const string One = "one";
    public const string Two = "two";
    public const string Contain = "contain";
    public const string Char = "char";
    public const string Format = "format";
    public const string IsbnFormat = "'###-#-##-######-#'";
    public const string Name = "name";
    public const string Surname = "surname";
    public const string Space = "space";
    public const string Patronymic = "patronymic";
    public const string Lending = "lending";
    public const string Empty = "empty";
    public const string Word = "word";
    public const string Only = "patronymic";
    public const string Written = "written";
}
