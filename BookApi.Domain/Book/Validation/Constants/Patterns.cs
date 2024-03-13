namespace Library.Domain.Book.Validation.Constants;

public sealed partial class ValidationPatterns
{
    [GeneratedRegex(@"^\d{3}-\d-\d{2}-\d{6}-\d$")]
    public static partial Regex Isbn();

    [GeneratedRegex(@"^(?i)((?<Cyryllic>[а-яё])|(?<Latin>[a-z])){1,}( ){0,1}((?<Cyryllic>[а-яё])|(?<Latin>[a-z])){2,}$")]
    public static partial Regex Title();

    [GeneratedRegex(@"^(?i)((?<Cyryllic>[а-яё])|(?<Latin>[a-z])){5,}$")]
    public static partial Regex Genre();

    [GeneratedRegex(@"^(?i)(((?<Cyryllic>[а-яё])|(?<Latin>[a-z])){2,} ){2}((?<Cyryllic>[а-яё])|(?<Latin>[a-z])){7,}$")]
    public static partial Regex Author();

    [GeneratedRegex(@"^(?i)(((?<Cyryllic>[а-яё])|(?<Latin>[a-z])){1,}( ){0,1})+((?<Cyryllic>[а-яё])|(?<Latin>[a-z])){2,}$")]
    public static partial Regex Description();
}
