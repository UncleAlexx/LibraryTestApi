namespace Library.Domain.Book.ValueObjects.Stock;

public sealed partial class AuthorObject : StringObject<AuthorObject>
{
    private AuthorObject(in string value, in bool success = true) : base(value, success) { }

    [JsonIgnore]
    public override string ErrorMessage { get; init; } = ValidationMessages.AuthorMessage;
    [JsonIgnore]
    public override sealed Bounds<int> Bounds { get; } = new Bounds<int>(13, 40);
    public static new string PropertyName { get; } = "Author";

    [GeneratedRegex(@"^(?i)(((?<Cyryllic>[а-яё])|(?<Latin>[a-z])){2,} ){2}((?<Cyryllic>[а-яё])|(?<Latin>[a-z])){7,}$")]
    public override sealed partial Regex Pattern();
}